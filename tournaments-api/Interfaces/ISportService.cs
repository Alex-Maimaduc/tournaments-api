using System.Collections.Generic;
using tournaments_api.DBModels;

namespace tournaments_api.Interfaces
{
    public interface ISportService
    {
        List<Sport> Get();
        Sport Get(int id);
        Sport Create(Sport sport);
        bool Update(Sport sport);
        void Delete(int id);
        List<MatchPlayers> GetMatchesPlayers(int id);
        List<TournamentPlayers> GetTournamentsPlayers(int id);
    }
}
