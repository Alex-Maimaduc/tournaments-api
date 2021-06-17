using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;
using tournaments_api.Enums;

namespace tournaments_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportController : ControllerBase
    {
        private readonly ISportService _sport;

        public SportController(ISportService sport)
        {
            _sport = sport;
        }

        [HttpGet]
        public IEnumerable<Sport> Get() =>
            _sport.Get();

        [HttpGet("{id}", Name = "GetSport")]
        public ActionResult<Sport> Get(int id)
        {
            var sport = _sport.Get(id);

            if (sport == null)
            {
                return NotFound();
            }

            return sport;
        }

        [HttpPost]
        public ActionResult<Sport> Create(Sport sport)
        {
            _sport.Create(sport);

            return CreatedAtRoute("GetSport", new { id = sport.Id }, sport);
        }

        [HttpPut]
        public IActionResult Update(Sport sport)
        {
            if (!_sport.Update(sport))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sport = _sport.Get(id);

            if (sport == null)
            {
                return NotFound();
            }

            _sport.Delete(id);

            return Ok();
        }

        [HttpGet("{id}/Matches/{status}/{period}")]
        public ActionResult<List<MatchPlayers>> GetMatches(int id, Status status, Period period)
        {
            return _sport.GetMatches(id, status, period);
        }

        [HttpGet("{id}/MatchesTeams/{status}/{period}")]
        public ActionResult<List<MatchTeams>> GetMatchesTeams(int id, Status status, Period period)
        {
            return _sport.GetMatchesTeams(id, status, period);
        }

        [HttpGet("{id}/Tournaments/{status}/{period}")]
        public ActionResult<List<TournamentPlayers>> GetTournaments(int id, Status status, Period period)
        {
            return _sport.GetTournaments(id, status, period);
        }

        [HttpGet("{id}/TournamentsTeams/{status}/{period}")]
        public ActionResult<List<TournamentTeams>> GetTournamentsTeams(int id, Status status, Period period)
        {
            return _sport.GetTournamentsTeams(id, status, period);
        }
    }
}
