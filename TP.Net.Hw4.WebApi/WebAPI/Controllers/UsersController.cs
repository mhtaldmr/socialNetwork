using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP.Net.Hw4.Application.Interfaces.Context;
using TP.Net.Hw4.Application.Interfaces.Repositories;

namespace MuhammetAliDemir.TP.Net.Hw4.WebAPI.Controllers
{
    [Route("/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetUserAll();

            if(users is null)
                return NotFound();

            return Ok(users);            
        }
    }
}
