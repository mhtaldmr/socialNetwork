using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP.Net.Hw.Application.Interfaces.Services;

namespace TP.Net.Hw.WebUI.Controllers
{
    [Route("emails")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult GetEmailSend()
        {
            _emailService.SendEmailReport();

            return Ok();
        }

    }
}
