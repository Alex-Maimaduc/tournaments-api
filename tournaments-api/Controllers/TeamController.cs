using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;
using tournaments_api.Models;
using tournaments_api.Enums;
using System;

namespace tournaments_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _team;

        public TeamController(ITeamService team)
        {
            _team = team;
        }

        [HttpGet]
        public IEnumerable<Team> Get() =>
            _team.Get();

        [HttpGet("{id}", Name = "GetTeam")]
        public ActionResult<Team> Get(int id)
        {
            var team = _team.Get(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        [HttpPost]
        public ActionResult<Team> Create([FromBody] Team team)
        {
            _team.Create(team);

            return CreatedAtRoute("GetTeam", new { id = team.Id }, team);
        }

        [HttpPut]
        public IActionResult Update(Team team)
        {
            if (!_team.Update(team))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (!_team.Delete(id))
            {
                return false;
            }

            return true;
        }

        [HttpGet("{id}/Matches/{status}/{period}")]
        public ActionResult<List<MatchTeams>> GetMatches(int id, Status status, Period period)
        {
            return _team.GetMatches(id, status, period);
        }

        [HttpGet("{id}/Tournaments/{status}/{period}")]
        public ActionResult<List<TournamentTeams>> GetTournaments(int id, Status status, Period period)
        {
            return _team.GetTournaments(id, status, period);
        }

        [HttpGet("GetTeamsForMatch/{sportId}/{startDate}/{endDate}")]
        public ActionResult<List<Team>> GetTeamsForMatch(int sportId,DateTime startDate,DateTime endDate)
        {
            return _team.GetTeamsForMatch(sportId, startDate, endDate);
        }
    }
}

