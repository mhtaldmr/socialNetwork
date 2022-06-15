using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP.Net.Hw.Application.Interfaces.Services;

namespace TP.Net.Hw.WebUI.Controllers
{
    [Route("/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public IActionResult GetExcelReport()
        {
            _reportService.GetUsersExcelReport();

            return Ok();
        }
    }
}
