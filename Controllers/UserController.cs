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

        // Constructor injection for UserService
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: UserController/Validate/5
        [HttpPost("Validate")]
        public ActionResult<string> Validate([FromForm] IFormCollection collection)
        {
            string email = collection["email"];
            string password = collection["password"];

            try
            {
                return JsonSerializer.Serialize(_userService.Validate(email, password));
            } 
            catch
            {
                return NotFound();
            }
            
        }

        // GET: UserController/Create
        [HttpPost("Create")]
        public ActionResult Create([FromForm] IFormCollection collection)
        {
            // Extract data from the form
            User newUser = new User
            {
                Name = collection["Name"], // Extracting the 'Name' parameter
                Address = collection["Address"], // Extracting the 'Address' parameter
                Phone = collection["Phone"], // Extracting the 'Phone' parameter
                Email = collection["Email"], // Extracting the 'Email' parameter
                Password = collection["Password"], // Extracting the 'Password' parameter
                Role = Enum.Parse<Role>(collection["Role"]), // Parsing 'Role' to the Role enum
                Id = long.Parse(collection["Id"]) // Parsing 'Id' to a long
            };
            _userService.Create(newUser);
            return Ok();
        }

        public ActionResult<string> AllVolunteer() 
        {
            User[] users = _userService.GetAllVolunteer();
            return JsonSerializer.Serialize(users);
        }

        public ActionResult<string> AllCooperator()
        {
            User[] users = _userService.GetAllCooperator();
            return JsonSerializer.Serialize(users);
        }

        // POST: UserController/Create
        [HttpPost]
        public ActionResult<string> Create()
        {
            User newUser = new User();
            try
            {
                return JsonSerializer.Serialize(newUser);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
