using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Modal;
using Server.Service;
using System.Text.Json;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;
        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        // GET: ReportController/Details/5
        public ActionResult<string> Details(int id)
        {
            return JsonSerializer.Serialize(_reportService.GetReport(id));
        }

        // GET: ReportController/Create
        public ActionResult<string> Create()
        {
            Report newReport = new Report();
            return JsonSerializer.Serialize(newReport);
        }

        // POST: ReportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<string> Create(IFormCollection collection)
        {
            try
            {
                // Extracting the form data and mapping it to a Report object
                Report newReport = new Report
                {
                    Address = collection["Address"], // Extract the 'Address' from the form
                    Description = collection["Description"], // Extract the 'Description' from the form
                    Email = collection["Email"] // Extract the 'Email' from the form
                };
                _reportService.Create(newReport);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        public ActionResult<string> AllReport()
        {
            try
            {
                return JsonSerializer.Serialize(_reportService.GetAllReports());
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
