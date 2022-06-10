using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TP.Net.Hw4.Application.Dtos;
using TP.Net.Hw4.Domain.Entity;
using TP.Net.Hw4.Infrastructure.Services;

namespace TP.Net.Hw4.WebApi.Controllers
{
    [Route("/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TokenGenerator _tokenGenerator;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(TokenGenerator tokenGenerator,UserManager<User> userManager,SignInManager<User> signInManager,IConfiguration configuration)
        {
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
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
                UserSurName = signup.UserSurName
            };

            var IsCreated = await _userManager.CreateAsync(newUser, signup.Password);

            if(IsCreated.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim("Email", newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var jwtToken = _tokenGenerator.GetToken(claims);

                return Ok(new {token = jwtToken});
            }
            else
            {
                return BadRequest(IsCreated.Errors);
            }

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserSignupDto login)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(login.Email);

                if (existingUser == null)
                    return BadRequest("usernull");
                if (await _userManager.IsLockedOutAsync(existingUser))
                    return BadRequest("userislocked");
                

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, login.Password);
                var singInResult = await _signInManager.CheckPasswordSignInAsync(existingUser, login.Password, false);

                if (!isCorrect)
                {
                    await _userManager.AccessFailedAsync(existingUser);
                    return BadRequest("accesfailed");
                }

                var claims = new List<Claim>
                {
                    new Claim("Email", existingUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                await _signInManager.SignInAsync(existingUser, false);

                var jwtToken = _tokenGenerator.GetToken(claims);

                return Ok(jwtToken);
            }

            return BadRequest("end");
        }
    }
}
