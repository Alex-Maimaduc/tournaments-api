using System.Collections.Generic;
using System.Linq;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;
using tournaments_api.Repository;
using Microsoft.EntityFrameworkCore;

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
            _db.TournamentTeams
            .Include("Matches.Sport")
            .Include("Matches.Gym")
            .Include("Matches.Gym.Owner")
            .Include("Matches.FirstTeam")
            .Include("Matches.SecondTeam")
            .Include(tournament => tournament.Matches)
            .FirstOrDefault(tournament => tournament.Id == id);

        public TournamentTeams Create(TournamentTeams tournament)
        {
            List<MatchTeams> matches = new List<MatchTeams>();

            tournament.Matches.ForEach(match =>
            {
                match.FirstTeam = _db.Teams.Find(match.FirstTeam.Id);
                match.SecondTeam = _db.Teams.Find(match.SecondTeam.Id);
                match.Sport = _db.Sports.Find(match.Sport.Id);
                match.Gym = _db.Gyms.Include(gym=>gym.Owner).FirstOrDefault(g=>g.Id==match.Gym.Id);
                matches.Add(match);
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

            List<MatchTeams> matches = new List<MatchTeams>();

            tournament.Matches.ForEach(match =>
            {
                match.FirstTeam = _db.Teams.Find(match.FirstTeam.Id);
                match.SecondTeam = _db.Teams.Find(match.SecondTeam.Id);
                match.Sport = _db.Sports.Find(match.Sport.Id);
                match.Gym = _db.Gyms.FirstOrDefault(g => g.Id == match.Gym.Id);
                matches.Add(match);
            });

            tournament.Matches = matches;

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
