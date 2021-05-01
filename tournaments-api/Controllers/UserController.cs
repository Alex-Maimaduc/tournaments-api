﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tournaments_api.Interfaces;
using tournaments_api.Models;

namespace tournaments_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;

        public UserController(IUserService user)
        {
            _user = user;
        }

        [HttpGet]
        public IEnumerable<User> Get() =>
            _user.Get();

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _user.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _user.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            if (!_user.Update(user))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var user = _user.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _user.Delete(id);

            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult AddSports(string id,List<int> sports)
        {
            if (!_user.AddSports(id, sports))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("{id}/FavoriteSports")]
        public ActionResult<List<Sport>> GetFavortieSports(string id)
        {
            List<Sport> sports = _user.GetFavoriteSports(id);

            if (sports == null)
            {
                return NotFound();
            }

            return sports;
        }

        [HttpDelete("{id}/FavoriteSport")]
        public IActionResult RemoveFavoriteSport(string id,int sportID)
        {
            if (!_user.RemoveFavoriteSport(id, sportID))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
