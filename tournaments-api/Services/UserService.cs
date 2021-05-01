using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using tournaments_api.Interfaces;
using tournaments_api.Models;
using tournaments_api.Repository;

namespace tournaments_api.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _db;

        public UserService(DatabaseContext db)
        {
            _db = db;
        }

        public List<User> Get() =>
            _db.Users.Include(u=>u.FavoriteSports).ToList();

        public User Get(string id) =>
            _db.Users.Find(id);

        public User Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();

            return user;
        }

        public bool Update(User user)
        {
            if (!_db.Users.Contains(user))
            {
                return false;
            }

            _db.Users.Update(user);
            _db.SaveChanges();

            return true;
        }

        public void Delete(string id)
        {
            User user = _db.Users.Find(id);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public bool AddSports(string id, List<int> sports)
        {
            User user = _db.Users.Find(id);

            if (user == null)
            {
                return false;
            }

            List<Sport> sportsToAdd = _db.Sports.Where(sport=>sports.Contains(sport.Id)).ToList();

            user.FavoriteSports.AddRange(sportsToAdd);

            _db.SaveChanges();

            return true;
        }

        public List<Sport> GetFavoriteSports(string id) {
            User user = _db.Users.Include(u => u.FavoriteSports).FirstOrDefault(u=>u.Id==id);

            if (user == null)
            {
                return null;
            }

            return user.FavoriteSports;
        }

        public bool RemoveFavoriteSport(string id,int sportId)
        {
            User user = _db.Users.Include(u => u.FavoriteSports).FirstOrDefault(u=>u.Id==id);

            if(user == null)
            {
                return false;
            }

            user.FavoriteSports.Remove(user.FavoriteSports.FirstOrDefault(s=>s.Id==sportId));
            _db.SaveChanges();

            return true;
        }
    }
}
