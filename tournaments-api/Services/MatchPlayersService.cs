using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;
using tournaments_api.Repository;

namespace tournaments_api.Services
{
    public class MatchPlayersService : IMatchPlayersService
    {
        private readonly DatabaseContext _db;

        public MatchPlayersService(DatabaseContext db)
        {
            _db = db;
        }

        public List<MatchPlayers> Get() =>
            _db.MatchesPlayers
            .Include(m=>m.FirstPlayer)
            .Include(m=>m.SecondPlayer)
            .ToList();

        public MatchPlayers Get(int id) =>
            _db.MatchesPlayers
            .Include(match=>match.FirstPlayer)
            .Include(match=>match.SecondPlayer)
            .Include(match=>match.Sport)
            .Include(match=>match.Gym)
            .Include("Gym.Owner")
            .FirstOrDefault(match=>match.Id==id);

        public MatchPlayers Create(MatchPlayers match)
        {
            match.Sport = _db.Sports.Find(match.Sport.Id);
            match.Gym = _db.Gyms.Find(match.Gym.Id);
            match.FirstPlayer = _db.Users.Find(match.FirstPlayer.Id);
            match.SecondPlayer = _db.Users.Find(match.SecondPlayer.Id);

            _db.MatchesPlayers.Add(match);
            _db.SaveChanges();

            return match;
        }

        public bool Update(MatchPlayers match)
        {
            if (!_db.MatchesPlayers.Contains(match))
            {
                return false;
            }

            match.Sport = _db.Sports.Find(match.Sport.Id);
            match.Gym = _db.Gyms.Find(match.Gym.Id);
            match.FirstPlayer = _db.Users.Find(match.FirstPlayer.Id);
            match.SecondPlayer = _db.Users.Find(match.SecondPlayer.Id);
            if (match.Tournament != null)
            {
                match.Tournament = _db.TournamentPlayers.Find(match.Tournament.Id);
            }

            _db.MatchesPlayers.Update(match);
            _db.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            MatchPlayers match = _db.MatchesPlayers.Find(id);

            _db.MatchesPlayers.Remove(match);
            _db.SaveChanges();
        }
    }
}
