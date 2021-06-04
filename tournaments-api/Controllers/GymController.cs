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
        public IActionResult Delete(int id)
        {
            Gym gym = _gyms.Get(id);

            if (gym == null)
            {
                return NotFound();
            }

            _gyms.Delete(id);

            return Ok();
        }

        [HttpGet("{id}/Matches/{status}/{period}")]
        public ActionResult<List<MatchPlayers>> GetMatches(int id, Status status, Period period)
        {
            return _gyms.GetMatches(id, status, period);
        }

        [HttpGet("{id}/Tournaments/{status}/{period}")]
        public ActionResult<List<TournamentPlayers>> GetTournaments(int id, Status status, Period period)
        {
            return _gyms.GetTournaments(id,status,period);
        }
    }
}
