using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tournaments_api.Interfaces;
using tournaments_api.Models;

namespace tournaments_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchPlayersController : ControllerBase
    {
        private readonly IMatchPlayersService _matchPlayers;

        public MatchPlayersController(IMatchPlayersService match)
        {
            _matchPlayers = match;
        }

        [HttpGet]
        public IEnumerable<MatchPlayers> Get() =>
            _matchPlayers.Get();

        [HttpGet("{id}", Name = "GetMatch")]
        public ActionResult<MatchPlayers> Get(int id)
        {
            var match = _matchPlayers.Get(id);

            if (match == null)
            {
                return NotFound();
            }

            return match;
        }

        [HttpPost]
        public ActionResult<MatchPlayers> Create(MatchPlayers match)
        {
            _matchPlayers.Create(match);

            return CreatedAtRoute("GetMatch", new { id = match.Id }, match);
        }

        [HttpPut]
        public IActionResult Update(MatchPlayers match)
        {
            if (!_matchPlayers.Update(match))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var match = _matchPlayers.Get(id);

            if (match == null)
            {
                return NotFound();
            }

            _matchPlayers.Delete(id);

            return Ok();
        }
    }
}
