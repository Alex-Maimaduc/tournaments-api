using System;
using System.Collections.Generic;
using System.Linq;
using tournaments_api.Interfaces;
using tournaments_api.Models;
using tournaments_api.Repository;

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
            _db.TournamentPlayers.Find(id);

        public TournamentPlayers Create(TournamentPlayers tournament)
        {
            List<MatchPlayers> matches = new List<MatchPlayers>();

            tournament.Matches.ForEach(match =>
            {
                matches.Add(_db.MatchesPlayers.Find(match.Id));
            });

            tournament.Matches = matches;

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
