using System.Collections.Generic;
using tournaments_api.Models;

namespace tournaments_api.Interfaces
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
