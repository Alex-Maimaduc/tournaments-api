using System;
using System.Collections.Generic;
using System.Linq;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;
using tournaments_api.Repository;
using Microsoft.EntityFrameworkCore;

namespace tournaments_api.Services
{
    public class TournamentPlayersService : ITournamentPlayersService
    {
        private readonly DatabaseContext _db;

        public TournamentPlayersService(DatabaseContext db)
        {
            _db = db;
        }

        public List<TournamentPlayers> Get() =>
            _db.TournamentPlayers.ToList();

        public TournamentPlayers Get(int id) =>
            _db.TournamentPlayers
            .Include("Matches.Sport")
            .Include("Matches.Gym")
            .Include("Matches.FirstPlayer")
            .Include("Matches.SecondPlayer")
            .Include(tournament => tournament.Matches)
            .FirstOrDefault(tournament => tournament.Id == id);

        public TournamentPlayers Create(TournamentPlayers tournament)
        {
            List<MatchPlayers> matches = new();

            tournament.Matches.ForEach(match =>
            {
                match.FirstPlayer = _db.Users.Find(match.FirstPlayer.Id);
                match.SecondPlayer = _db.Users.Find(match.SecondPlayer.Id);
                match.Sport = _db.Sports.Find(match.Sport.Id);
                match.Gym = _db.Gyms.Find(match.Gym.Id);
                matches.Add(match);
            });

            tournament.Matches = matches;

            tournament.Gym = _db.Gyms.Find(tournament.Gym.Id);

            tournament.Sport = _db.Sports.Find(tournament.Sport.Id);

            _db.TournamentPlayers.Add(tournament);
            _db.SaveChanges();

            return tournament;
        }

        public bool Update(TournamentPlayers tournament)
        {
            if (!_db.TournamentPlayers.Contains(tournament))
            {
                return false;
            }

            List<MatchPlayers> matches = new();

            tournament.Matches.ForEach(match =>
            {
                match.FirstPlayer = _db.Users.Find(match.FirstPlayer.Id);
                match.SecondPlayer = _db.Users.Find(match.SecondPlayer.Id);
                match.Sport = _db.Sports.Find(match.Sport.Id);
                match.Gym = _db.Gyms.Find(match.Gym.Id);
                matches.Add(match);
            });

            tournament.Matches = matches;

            tournament.Gym = _db.Gyms.Find(tournament.Gym.Id);

            tournament.Sport = _db.Sports.Find(tournament.Sport.Id);

            _db.TournamentPlayers.Update(tournament);
            _db.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            TournamentPlayers tournament = _db.TournamentPlayers.Find(id);

            _db.TournamentPlayers.Remove(tournament);
            _db.SaveChanges();
        }
    }
}
