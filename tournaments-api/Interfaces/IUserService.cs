using System.Collections.Generic;
using System.Linq;
using tournements.Data;

namespace tournaments.Services
{
    public interface IUserService
    {
        List<User> Get();
        User Get(string id);
        User Create(User user);
        bool Update(User user);
        void Delete(string id);
    }
}
