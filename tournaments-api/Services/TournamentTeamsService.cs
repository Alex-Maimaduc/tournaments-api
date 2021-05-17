using System.Collections.Generic;
using System.Linq;
using tournaments_api.Interfaces;
using tournaments_api.Models;
using tournaments_api.Repository;

namespace tournaments_api.Services
{
    public class TournamentTeamsService : ITournamentTeamsService
    {
        private readonly DatabaseContext _db;

        public TournamentTeamsService(DatabaseContext db)
        {
            _db = db;
        }

        public List<TournamentTeams> Get() =>
            _db.TournamentTeams.ToList();

        public TournamentTeams Get(int id) =>
            _db.TournamentTeams.Find(id);

        public TournamentTeams Create(TournamentTeams tournament)
        {
            List<MatchTeams> matches = new List<MatchTeams>();

            tournament.Matches.ForEach(match =>
            {
                matches.Add(_db.MatchTeams.Find(match.Id));
            });

            tournament.Matches = matches;

            _db.TournamentTeams.Add(tournament);
            _db.SaveChanges();

            return tournament;
        }

        public bool Update(TournamentTeams tournament)
        {
            if (!_db.TournamentTeams.Contains(tournament))
            {
                return false;
            }

            _db.TournamentTeams.Update(tournament);
            _db.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            TournamentTeams tournament = _db.TournamentTeams.Find(id);

            _db.TournamentTeams.Remove(tournament);
            _db.SaveChanges();
        }
    }
}
