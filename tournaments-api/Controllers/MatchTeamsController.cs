using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tournaments_api.Interfaces;
using tournaments_api.Models;

namespace tournaments_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchTeamsController : ControllerBase
    {
        private readonly IMatchTeamsService _matchTeams;

        public MatchTeamsController(IMatchTeamsService matchTeams)
        {
            _matchTeams = matchTeams;
        }


        [HttpGet]
        public IEnumerable<MatchTeams> Get() =>
            _matchTeams.Get();

        [HttpGet("{id}", Name = "GetMatchTeams")]
        public ActionResult<MatchTeams> Get(int id)
        {
            var match = _matchTeams.Get(id);

            if (match == null)
            {
                return NotFound();
            }

            return match;
        }

        [HttpPost]
        public ActionResult<MatchTeams> Create(MatchTeams match)
        {
            _matchTeams.Create(match);

            return CreatedAtRoute("GetMatch", new { id = match.Id }, match);
        }

        [HttpPut]
        public IActionResult Update(MatchTeams match)
        {
            if (!_matchTeams.Update(match))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var match = _matchTeams.Get(id);

            if (match == null)
            {
                return NotFound();
            }

            _matchTeams.Delete(id);

            return Ok();
        }
    }
}
