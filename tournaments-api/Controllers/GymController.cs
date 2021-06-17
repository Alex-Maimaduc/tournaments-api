using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tournaments_api.DBModels;
using tournaments_api.Enums;
using tournaments_api.Interfaces;

namespace tournaments_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GymController : ControllerBase
    {
        private readonly IGymService _gyms;

        public GymController(IGymService gyms)
        {
            _gyms = gyms;
        }

        [HttpGet]
        public IEnumerable<Gym> Get() =>
           _gyms.Get();

        [HttpGet("{id}", Name = "GetGym")]
        public ActionResult<Gym> Get(int id)
        {
            Gym gym = _gyms.Get(id);

            if (gym == null)
            {
                return NotFound();
            }

            return gym;
        }

        [HttpPost]
        public ActionResult<Gym> Create(Gym gym)
        {
            _gyms.Create(gym);

            return CreatedAtRoute("GetGym", new { id = gym.Id }, gym);
        }

        [HttpPut]
        public IActionResult Update(Gym gym)
        {
            if (!_gyms.Update(gym))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (!_gyms.Delete(id))
            {
                return false;
            }

            return true;
        }

        [HttpGet("{id}/Matches/{status}/{period}/{sportId}")]
        public ActionResult<List<MatchPlayers>> GetMatches(int id, Status status, Period period, int sportId)
        {
            return _gyms.GetMatches(id, status, period, sportId);
        }
        [HttpGet("{id}/MatchesTeams/{status}/{period}/{sportId}")]
        public ActionResult<List<MatchTeams>> GetMatchesTeams(int id, Status status, Period period, int sportId) =>
            _gyms.GetMatchesTeams(id, status, period, sportId);

        [HttpGet("{id}/Tournaments/{status}/{period}/{sportId}")]
        public ActionResult<List<TournamentPlayers>> GetTournaments(int id, Status status, Period period, int sportId) =>
             _gyms.GetTournaments(id, status, period, sportId);

        [HttpGet("{id}/TournamentsTeams/{status}/{period}/{sportId}")]
        public ActionResult<List<TournamentTeams>> GetTournamentsTeams(int id, Status status, Period period, int sportId) =>
             _gyms.GetTournamentsTeams(id, status, period, sportId);

    }
}
