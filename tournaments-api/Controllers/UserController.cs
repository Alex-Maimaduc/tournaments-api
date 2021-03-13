using Microsoft.AspNetCore.Mvc;
using tournaments.Services;
using tournements.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tournaments_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }


        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            if (user.Mail == null)
            {
                return BadRequest();
            }

            Response response=_user.AddUser(user);

            return Ok(response);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] User user)
        {
            if (user.Mail == null)
            {
                return BadRequest();
            }

            _user.Update(user);

            return Ok();
        }
            
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetName(string? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return Ok(_user.GetName(id));
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult Delete(string id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            _user.Delete(id);
            return Ok();
        }
    }
}
