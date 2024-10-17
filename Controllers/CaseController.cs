using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Server.Modal;
using Server.Service;
using System.Text.Json;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaseController : ControllerBase
    {
        private readonly CaseService _caseService;
        private readonly VolunteerCaseService _volunteerCaseService;

        public class AssignCooperatorReqBody
        {
            public int cooperatorId { get; set; }
            public int caseId { get; set; }
        }

        public CaseController(CaseService caseService, VolunteerCaseService volunteerCaseService)
        {
            _caseService = caseService;
            _volunteerCaseService = volunteerCaseService;
        }

        // GET: CaseController/Details/5
        [HttpGet("Details/{id}")]
        public ActionResult<string> Details(int id)
        {
            return JsonSerializer.Serialize(_caseService.GetCase(id));
        }

        [HttpGet("AllCase")]
        public ActionResult<string> AllCase()
        {
            return JsonSerializer.Serialize(_caseService.GetAllCases());
        }

        [HttpPost("AssignCooperator")]
        public ActionResult<string> AssignCooperator([FromBody] AssignCooperatorReqBody body)
        {
            Case caseObj = _caseService.GetCase(body.caseId);
            caseObj.CooperatorId = body.cooperatorId;
            _caseService.Update(caseObj);
            return JsonSerializer.Serialize(_caseService);
        }

        [HttpPost("Create")]
        public ActionResult<string> Create([FromBody] Case newCase)
        {
            newCase.Id = 0;
            _caseService.Create(newCase);
            return Ok();
        }

        [HttpPost("AssignedCases/{cooperatorId}")]
        public ActionResult<string> AssignedCases(int cooperatorId)
        {
            Case[] caseList = _caseService.GetCaseByCooperatorId(cooperatorId);
            return JsonSerializer.Serialize(caseList);
        }
    }
}
