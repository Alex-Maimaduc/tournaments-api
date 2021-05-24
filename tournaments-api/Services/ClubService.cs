using System.Collections.Generic;
using System.Linq;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;
using tournaments_api.Repository;

namespace tournaments_api.Services
{
    public class ClubService : IClubService
    {
        private readonly DatabaseContext _db;

        public ClubService(DatabaseContext db)
        {
            _db = db;
        }

        public IEnumerable<Club> Get() =>
            _db.Clubs;

        public Club Get(int id) =>
            _db.Clubs.Find(id);

        public Club Create(Club club)
        {
            User owner = _db.Users.Find(club.Owner.Id);

            club.Owner = owner;

            List<Team> teams = new List<Team>();

            club.Teams.ForEach(team =>
            {
                teams.Add(_db.Teams.Find(team.Id));
            });

            club.Teams = teams;

            _db.Clubs.Add(club);
            _db.SaveChanges();

            return club;
        }

        public bool Update(Club club)
        {
            if (!_db.Clubs.Contains(club))
            {
                return false;
            }

            _db.Clubs.Update(club);
            _db.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            Club club = _db.Clubs.Find(id);

            _db.Clubs.Remove(club);
            _db.SaveChanges();
        }
    }
}
