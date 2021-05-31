using System.Collections.Generic;
using System.Linq;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;
using tournaments_api.Repository;
using Microsoft.EntityFrameworkCore;

namespace tournaments_api.Services
{
    public class SportService : ISportService
    {
        private readonly DatabaseContext _db;

        public SportService(DatabaseContext db)
        {
            _db = db;
        }

        public List<Sport> Get() =>
            _db.Sports.ToList();

        public Sport Get(int id) =>
            _db.Sports.Find(id);

        public Sport Create(Sport sport)
        {
            _db.Sports.Add(sport);
            _db.SaveChanges();

            return sport;
        }

        public bool Update(Sport sport)
        {
            if (_db.Sports.Find(sport.Id) == null)
            {
                return false;
            }
            _db.Sports.Update(sport);
            _db.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            Sport sport = _db.Sports.Find(id);

            _db.Sports.Remove(sport);
            _db.SaveChanges();
        }

        public List<MatchPlayers> GetMatchesPlayers(int id)
        {
            return _db.MatchesPlayers
                .Include(match=>match.FirstPlayer)
                .Include(match=>match.SecondPlayer)
                .Include(match=>match.Gym)
                .Where(m => m.Sport.Id == id)
                .ToList();
        }

        public List<TournamentPlayers> GetTournamentsPlayers(int id)
        {
            return _db.TournamentPlayers
                .Include(tournament=>tournament.Matches)
                .Where(tournament => tournament.Matches.Any(match => match.Sport.Id == id))
                .ToList();
        }
    }
}
