using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            if (user.Mail == null || user.Password == null)
            {
                return BadRequest();
            }

            Response response=_user.AddUser(user);

            return Ok(response);

        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]User user)
        {
            if (user.Mail == null || user.Password == null)
            {
                return BadRequest();
            }

            Response response = _user.Login(user);

            return Ok(response);
        }

    }
}
