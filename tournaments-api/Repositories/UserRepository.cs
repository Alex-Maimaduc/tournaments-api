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

        public Response AddUser(User user)
        {
            Response model = new Response();
            if (user != null)
            {
                if (!_db.Users.Any(u => u.Mail == user.Mail))
                {
                    try
                    {
                        _db.Users.Add(user);
                        _db.SaveChanges();

                        model.Flag = true;
                        model.Message = "Registered successfully!";
                    }
                    catch
                    {
                        model.Flag = false;
                        model.Message = "Error while creating account!";
                    }
                }
                else
                {
                    model.Flag = false;
                    model.Message = "Email allready in use!";
                }
            }
            return model;
        }

        public void Update(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

    }
}
