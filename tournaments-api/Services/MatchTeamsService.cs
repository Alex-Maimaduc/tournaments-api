using System;
using System.Collections.Generic;
using System.Linq;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;
using tournaments_api.Repository;
using Microsoft.EntityFrameworkCore;

namespace tournaments_api.Services
{
    public class MatchTeamsService:IMatchTeamsService
    {
        private readonly DatabaseContext _db;

        public MatchTeamsService(DatabaseContext db)
        {
            _db = db;
        }

        public List<MatchTeams> Get() =>
            _db.MatchTeams.ToList();

        public MatchTeams Get(int id) =>
            _db.MatchTeams
            .Include(match => match.FirstTeam)
            .Include(match => match.SecondTeam)
            .Include(match => match.Sport)
            .Include(match => match.Gym)
            .Include("Gym.Owner")
            .Include("Gym.Members")
            .FirstOrDefault(match=>match.Id==id);

        public MatchTeams Create(MatchTeams match)
        {
            match.Sport = _db.Sports.Find(match.Sport.Id);
            match.Gym = _db.Gyms.Find(match.Gym.Id);
            match.FirstTeam = _db.Teams.Find(match.FirstTeam.Id);
            match.SecondTeam = _db.Teams.Find(match.SecondTeam.Id);

            _db.MatchTeams.Add(match);
            _db.SaveChanges();

            return match;
        }

        public bool Update(MatchTeams match)
        {
            if (!_db.MatchTeams.Contains(match))
            {
                return false;
            }

            match.Sport = _db.Sports.Find(match.Sport.Id);
            match.Gym = _db.Gyms.Find(match.Gym.Id);
            match.FirstTeam = _db.Teams.Find(match.FirstTeam.Id);
            match.SecondTeam = _db.Teams.Find(match.SecondTeam.Id);

            if (match.Tournament != null)
            {
                match.Tournament = _db.TournamentTeams.Find(match.Tournament.Id);
            }

            _db.MatchTeams.Update(match);
            _db.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            MatchTeams match = _db.MatchTeams.Find(id);

            _db.MatchTeams.Remove(match);
            _db.SaveChanges();
        }
    }
}
