using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;
using System;
using tournaments_api.Enums;
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

        [HttpDelete("{id}/DeleteFavoriteSport/{sportId}")]
        public IActionResult RemoveFavoriteSport(string id,int sportId)
        {
            if (!_user.RemoveFavoriteSport(id, sportId))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("{id}/GetTeam")]
        public ActionResult<int> GetTeam(string id)
        {
            int teamId = _user.GetTeam(id);

            if (teamId == -1)
            {
                return NotFound();
            }

            return teamId;
        }

        [HttpGet("{id}/Matches/{status}/{period}")]
        public ActionResult<List<MatchPlayers>> GetMatches(string id,Status status, Period period)
        {
            return _user.GetMatches(id,status,period);
        }

        [HttpGet("{id}/Tournaments/{status}/{period}")]
        public ActionResult<List<TournamentPlayers>> GetTournments(string id,Status status, Period period)
        {
            return _user.GetTournaments(id,status,period);
        }

        [HttpGet("{id}/GetGym")]
        public ActionResult<int> GetGym(string id)
        {
            int gymId= _user.GetGym(id);

            if (gymId == -1)
            {
                return NotFound();
            }

            return gymId;
        }

        [HttpGet("{id}/MatchesHistory/{sportId}/{startDate}/{endDate}")]
        public ActionResult<List<MatchPlayers>> GetMatchesHistory(string id,int sportId, DateTime startDate, DateTime endDate)
        {
            return _user.GetMatchesHistory(id,sportId,startDate,endDate);
        }

        [HttpGet("GetUsersForMatch/{sportId}/{startDate}/{endDate}")]
        public ActionResult<List<User>> GetUsersForMatch(int sportId,DateTime startDate,DateTime endDate)
        {
            return _user.GetUsersForMatch(sportId,startDate, endDate);
        }

        [HttpGet("{id}/GetStats/{sportId}/{period}")]
        public ActionResult<Stats> GetStatus(string id, int sportId, Period period)
        {
            return _user.GetStats(id, sportId, period);
        }

        [HttpGet("GetUsersForTeam")]
        public ActionResult<List<User>> GetUsersForTeam()
        {
            return _user.GetUsersForTeam();
        }

        [HttpGet("GetUsersForGym")]
        public ActionResult<List<User>> GetUsersForGym()
        {
            return _user.GetUsersForGym();
        }
    }
}
