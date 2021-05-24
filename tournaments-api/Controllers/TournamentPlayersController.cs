using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;

namespace tournaments_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentPlayersController : ControllerBase
    {
        private readonly ITournamentPlayersService _tournamentPlayers;

        public TournamentPlayersController(ITournamentPlayersService tournamentPlayers)
        {
            _tournamentPlayers = tournamentPlayers;
        }

        [HttpGet]
        public IEnumerable<TournamentPlayers> Get() =>
            _tournamentPlayers.Get();

        [HttpGet("{id}", Name ="GetTournamentPlayers")]
        public ActionResult<TournamentPlayers> Get(int id)
        {
            var tournament = _tournamentPlayers.Get(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return tournament;
        }

        [HttpPost]
        public ActionResult<TournamentPlayers> Create(TournamentPlayers tournament)
        {
            _tournamentPlayers.Create(tournament);

            return CreatedAtRoute("GetTournamentPlayers", new { id = tournament.Id }, tournament);
        }

        [HttpPut]
        public IActionResult Update(TournamentPlayers tournament)
        {
            if (!_tournamentPlayers.Update(tournament))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tournament = _tournamentPlayers.Get(id);

            if (tournament == null)
            {
                return NotFound();
            }

            _tournamentPlayers.Delete(id);

            return Ok();
        }
    }
}
