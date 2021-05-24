using System.Collections.Generic;
using tournaments_api.DBModels;

namespace tournaments_api.Interfaces
{
    public interface ITournamentTeamsService
    {
        List<TournamentTeams> Get();
        TournamentTeams Get(int id);
        TournamentTeams Create(TournamentTeams tournament);
        bool Update(TournamentTeams tournament);
        void Delete(int id);
    }
}
