using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;

namespace tournaments_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubs;

        public ClubController(IClubService clubs)
        {
            _clubs = clubs;
        }

        [HttpGet]
        public IEnumerable<Club> Get() =>
            _clubs.Get();

        [HttpGet("{id}", Name="GetClub")]
        public ActionResult<Club> Get(int id)
        {
            Club club=_clubs.Get(id);

            if (club == null)
            {
                return NotFound();
            }

            return club;
        }

        [HttpPost]
        public ActionResult<Club> Create(Club club)
        {
            _clubs.Create(club);

            return CreatedAtRoute("GetClub", new { id = club.Id }, club);
        }

        [HttpPut]
        public IActionResult Update(Club club)
        {
            if (!_clubs.Update(club))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Club club = _clubs.Get(id);

            if (club == null)
            {
                return NotFound();
            }

            _clubs.Delete(id);

            return Ok();
        }
    }
}
