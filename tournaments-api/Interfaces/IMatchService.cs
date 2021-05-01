using System.Collections.Generic;
using tournaments_api.Models;

namespace tournaments_api.Interfaces
{
    public interface IMatchService
    {
        List<Match> Get();
        Match Get(int id);
        Match Create(Match match);
        bool Update(Match match);
        void Delete(int id);
    }
}
