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

            Response response = _user.AddUser(user);

            return Ok(response);

        }

        /// <summary>
        /// Update the <see cref="User"/> model.
        /// </summary>
        /// <param name="user"><see cref="User"/> model</param>
        /// <returns>NoContent.</returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult Update([FromBody] User user)
        {
            if (user.Mail == null)
            {
                return BadRequest();
            }

            _user.Update(user);

            return NoContent();
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

        /// <summary>
        /// Get the <see cref="User"/> model with id.
        /// </summary>
        /// <param name="id">Model id.</param>
        /// <returns>Model with id.</returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(string? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return Ok(_user.GetUser(id));
        }

        /// <summary>
        /// Delete the <see cref="User" model with id./>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoContent.</returns>
        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            _user.Delete(id);
            return NoContent();
        }
    }
}
