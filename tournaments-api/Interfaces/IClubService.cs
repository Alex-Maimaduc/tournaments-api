using System.Collections.Generic;
using tournaments_api.Models;

namespace tournaments_api.Interfaces
{
    public interface IClubService
    {
        IEnumerable<Club> Get();
        Club Get(int id);
        Club Create(Club club);
        bool Update(Club club);
        void Delete(int id);
    }
}
