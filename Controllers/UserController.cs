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
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly VolunteerCaseService _volunteerCaseService;
        private readonly CaseService _caseService;

        public class ValidateReqBody
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class JoinCaseReqBody
        {
            public long volunteerId { get; set; }
            public long caseId { get; set; }
        }

        // Constructor injection for UserService
        public UserController(UserService userService, VolunteerCaseService volunteerCaseService, CaseService caseService)
        {
            _userService = userService;
            _volunteerCaseService = volunteerCaseService;
            _caseService = caseService;
        }

        // GET: UserController/Validate/5
        [HttpPost("Validate")]
        public ActionResult<string> Validate([FromBody] ValidateReqBody body)
        {

            try
            {
                return JsonSerializer.Serialize(_userService.Validate(body.Email, body.Password));
            } 
            catch
            {
                return NotFound();
            }
            
        }

        // GET: UserController/Create
        [HttpPost("Create")]
        public ActionResult Create([FromBody] User user)
        {
            _userService.Create(user);
            return Ok();
        }

        [HttpGet("AllVolunteer")]
        public ActionResult<string> AllVolunteer() 
        {
            User[] users = _userService.GetAllVolunteer();
            return JsonSerializer.Serialize(users);
        }

        [HttpGet("AllVolunteer")]
        public ActionResult<string> AllCooperator()
        {
            User[] users = _userService.GetAllCooperator();
            return JsonSerializer.Serialize(users);
        }

        [HttpGet("JoinedCase/{volunteerId}")]
        public ActionResult<string> JoinedCase(long volunteerId)
        {
            VolunteerCase[] volunteerCase = _volunteerCaseService.GetCasesByVolunteer(volunteerId);
            List<Case> caseList = new List<Case>();
            foreach (var item in volunteerCase)
            {
                caseList.Add(_caseService.GetCase(item.caseId));
            }
            return JsonSerializer.Serialize(caseList.ToArray());
        }

        [HttpPost("JoinCase")]
        public ActionResult<string> JoinCase([FromBody] JoinCaseReqBody body)
        {
            _volunteerCaseService.AssignVolunteerToCase(body.volunteerId, body.caseId);
            return Ok();
        }
    }
}
