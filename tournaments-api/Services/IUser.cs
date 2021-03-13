using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tournements.Data;

namespace tournaments.Services
{
    public interface IUser
    {
        User GetUser(int? id);
        IQueryable<User> GetStudents { get; }
        Response AddUser(User user);
        void Update(User user);
        void Delete(string id);
        string GetName(string id);
    }
}
