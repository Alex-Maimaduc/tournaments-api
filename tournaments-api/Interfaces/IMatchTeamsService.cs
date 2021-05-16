using System.Collections.Generic;
using tournaments_api.Models;

namespace tournaments_api.Interfaces
{
    public interface IMatchTeamsService
    {
        List<MatchTeams> Get();
        MatchTeams Get(int id);
        MatchTeams Create(MatchTeams match);
        bool Update(MatchTeams match);
        void Delete(int id);
    }
}
