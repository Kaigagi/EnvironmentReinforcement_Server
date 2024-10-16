using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        [HttpGet("getall")]
        public string GetAll()
        {
            return "Hello";
        }
    }
}
