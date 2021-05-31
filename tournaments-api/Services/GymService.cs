﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using tournaments_api.DBModels;
using tournaments_api.Interfaces;
using tournaments_api.Repository;

namespace tournaments_api.Services
{
    public class GymService : IGymService
    {
        private readonly DatabaseContext _db;

        public GymService(DatabaseContext db)
        {
            _db = db;
        }

        public IEnumerable<Gym> Get() =>
            _db.Gyms;

        public Gym Get(int id) =>
            _db.Gyms.Include(gym=>gym.Owner).FirstOrDefault(gym=>gym.Id==id);

        public Gym Create(Gym gym)
        {
            User owner = _db.Users.Find(gym.Owner.Id);

            gym.Owner = owner;

            _db.Gyms.Add(gym);
            _db.SaveChanges();

            return gym;
        }

        public bool Update(Gym gym)
        {
            if (!_db.Gyms.Contains(gym))
            {
                return false;
            }

            _db.Gyms.Update(gym);
            _db.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            Gym gym = _db.Gyms.Find(id);

            _db.Gyms.Remove(gym);
            _db.SaveChanges();
        }

        public List<MatchPlayers> GetMatches(int id)
        {
            return _db.MatchesPlayers
                .Include(match => match.FirstPlayer)
                .Include(match => match.SecondPlayer)
                .Include(match => match.Sport)
                .Where(match => match.Gym.Id == id)
                .ToList();
        }

        public List<TournamentPlayers> GetTournaments(int id)
        {
            return _db.TournamentPlayers
                .Include(tournament=>tournament.Matches)
                .Where(tournament => tournament.Matches.Any(match => match.Gym.Id == id))
                .ToList();
        }
    }
}
