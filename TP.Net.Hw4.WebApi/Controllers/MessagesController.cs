using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP.Net.Hw4.Infrastructure.Persistence.Context;

namespace TP.Net.Hw4.WebApi.Controllers
{
    [Route("messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly SocialNetworkDbContext _context;

        public MessagesController(SocialNetworkDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetMessagesByFilter()
        {




            return Ok();
        }
    }
}
