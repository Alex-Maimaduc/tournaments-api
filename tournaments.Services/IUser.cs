using System;
using System.Linq;
using tournements.Data;

namespace tournaments.Services
{
    public interface IUser
    {
        User GetUser(int? id);
        IQueryable<User> GetStudents { get; }
        Response AddUser(User user);
        void Update(User user);
        void Delete(int id);
        Response Login(User user);
    }
}
