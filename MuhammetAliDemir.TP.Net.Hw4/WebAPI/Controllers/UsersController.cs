using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuhammetAliDemir.TP.Net.Hw4.Application.Interfaces;

namespace MuhammetAliDemir.TP.Net.Hw4.WebAPI.Controllers
{
    [Route("/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISocialNetworkDbContext _socialNetworkDbContext;

        public UsersController(ISocialNetworkDbContext socialNetworkDbContext)
        {
            _socialNetworkDbContext = socialNetworkDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _socialNetworkDbContext.Users;

            if(users is null)
                return NotFound();

            return Ok(users);            
        }
    }
}
