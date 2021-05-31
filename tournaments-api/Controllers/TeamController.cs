using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;
using tournaments_api.Models;

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
        public ActionResult<Team> Create([FromBody] CreateTeamInput teamInput)
        {
            _team.Create(teamInput);

            return CreatedAtRoute("GetTeam", new { id = teamInput.Team.Id }, teamInput.Team);
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
        public IActionResult Delete(int id)
        {
            var team = _team.Get(id);

            if (team == null)
            {
                return NotFound();
            }

            _team.Delete(id);

            return Ok();
        }

        [HttpGet("{id}/Matches")]
        public ActionResult<List<MatchTeams>> GetMatches(int id)
        {
            return _team.GetMatches(id);
        }

        [HttpGet("{id}/Tournaments")]
        public ActionResult<List<TournamentTeams>> GetTournaments(int id)
        {
            return _team.GetTournaments(id);
        }
    }
}
