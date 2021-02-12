using System;
using System.Linq;
using tournaments.Services;
using tournements.Data;

namespace tournaments.Repository
{
    public class UserRepository : IUser
    {
        private readonly UserDbContext _db;

        public UserRepository(UserDbContext db)
        {
            _db = db;
        }

        public IQueryable<User> GetStudents => _db.Users;

        public void Delete(int id)
        {
            User user = _db.Users.Find(id);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public User GetUser(int? id)
        {
            return _db.Users.Find(id);
        }

        public void Add(User user)
        {
            user.encriptPassword();
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void Update(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void Register(string mail, string password)
        {
            _db.Users.Add(new User(mail, password));
            _db.SaveChanges();
        }
    }
}
