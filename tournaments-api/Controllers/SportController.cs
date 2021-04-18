using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tournaments_api.Interfaces;
using tournaments_api.Models;

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
    }
}
