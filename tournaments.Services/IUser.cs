using System;
using System.Linq;
using tournements.Data;

namespace tournaments.Services
{
    public interface IUser
    {
        User GetUser(int? id);
        IQueryable<User> GetStudents { get; }
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        void Register(string email, string password);
    }
}
