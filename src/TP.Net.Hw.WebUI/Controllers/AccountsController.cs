using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TP.Net.Hw.Application.Dtos.Requests;
using TP.Net.Hw.Application.Interfaces.Repositories;
using TP.Net.Hw.Application.Interfaces.Services;
using TP.Net.Hw.Application.Interfaces.Services.RabbitMq;
using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.WebUI.Controllers
{
    [Route("/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IAccountRepository _repository;
        private readonly IPublisherService _publisherService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountsController(ITokenGenerator tokenGenerator, UserManager<User> userManager, SignInManager<User> signInManager, IAccountRepository repository, IPublisherService publisherService)
        {
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = repository;
            _publisherService = publisherService;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignupDto signup)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(signup.Email);
            if (user is not null)
                throw new Exception("There is a user with this email!");

            var newUser = new User()
            {
                Email = signup.Email,
                PasswordHash = signup.Password,
                UserName = signup.UserName,
                FirstName = signup.FirstName,
                LastName = signup.LastName,
                RegisteredAt = DateTime.Now,
                IsActive = true
            };

            var IsCreated = await _userManager.CreateAsync(newUser, signup.Password);

            if (IsCreated.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim("Email", newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var jwtToken = _tokenGenerator.GetToken(claims);
                newUser.RefreshToken = jwtToken.RefreshToken;
                newUser.RefreshTokenExpireDate = jwtToken.Expiration.AddMinutes(5);
                await _userManager.UpdateAsync(newUser);

                //Publishing the user when a new user is created!.
                _publisherService.Publish(newUser, "email", "email1");

                return Ok(new { token = jwtToken });
            }

            return BadRequest(IsCreated.Errors);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(login.Email);

            if (existingUser == null)
                return BadRequest("User does not exist!");
            if (await _userManager.IsLockedOutAsync(existingUser))
                return BadRequest("User is Locked");


            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, login.Password);
            var singInResult = await _signInManager.CheckPasswordSignInAsync(existingUser, login.Password, false);

            if (!isCorrect)
            {
                await _userManager.AccessFailedAsync(existingUser);
                return BadRequest("Access Failed");
            }

            var claims = new List<Claim>
            {
                new Claim("Email", existingUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            await _signInManager.SignInAsync(existingUser, false);

            var jwtToken = _tokenGenerator.GetToken(claims);
            existingUser.RefreshToken = jwtToken.RefreshToken;
            existingUser.RefreshTokenExpireDate = jwtToken.Expiration.AddMinutes(5);
            await _userManager.UpdateAsync(existingUser);

            return Ok(new { token = jwtToken });

        }

        [HttpGet("refreshtoken")]
        public async Task<IActionResult> GetRefreshToken([FromQuery] string refreshToken)
        {
            var user = await _repository.GetRefreshToken(refreshToken);

            if (user == null)
                return BadRequest("Users Refresh Token Expired or Doesnt Exist!");

            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            await _signInManager.SignInAsync(user, false);

            var jwtToken = _tokenGenerator.GetToken(claims);
            user.RefreshToken = jwtToken.RefreshToken;
            user.RefreshTokenExpireDate = jwtToken.Expiration.AddMinutes(5);
            await _userManager.UpdateAsync(user);

            return Ok(new { token = jwtToken });

        }
    }
}
