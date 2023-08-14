using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(StaticDB.UserNames);
        }


        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            if (id >= 0 && id < StaticDB.UserNames.Count)
            {
                return Ok(StaticDB.UserNames[id]);
            }
            return NotFound();
        }
    }
}
