using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;

namespace tournaments_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentTeamsController : ControllerBase
    {
        private readonly ITournamentTeamsService _tournamentTeams;

        public TournamentTeamsController(ITournamentTeamsService tournamentTeams)
        {
            _tournamentTeams = tournamentTeams;
        }

        [HttpGet]
        public IEnumerable<TournamentTeams> Get() =>
            _tournamentTeams.Get();

        [HttpGet("{id}", Name = "GetTournamentTeams")]
        public ActionResult<TournamentTeams> Get(int id)
        {
            var tournament = _tournamentTeams.Get(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return tournament;
        }

        [HttpPost]
        public ActionResult<TournamentTeams> Create(TournamentTeams tournament)
        {
            _tournamentTeams.Create(tournament);

            return CreatedAtRoute("GetTournamentTeams", new { id = tournament.Id }, tournament);
        }

        [HttpPut]
        public IActionResult Update(TournamentTeams tournament)
        {
            if (!_tournamentTeams.Update(tournament))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var tournament = _tournamentTeams.Get(id);

            if (tournament == null)
            {
                return NotFound();
            }

            _tournamentTeams.Delete(id);

            return Ok();
        }
    }
}
