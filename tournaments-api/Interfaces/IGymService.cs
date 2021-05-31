using System.Collections.Generic;
using tournaments_api.DBModels;

namespace tournaments_api.Interfaces
{
    public interface IGymService
    {
        IEnumerable<Gym> Get();
        Gym Get(int id);
        Gym Create(Gym gym);
        bool Update(Gym gym);
        void Delete(int id);
        List<MatchPlayers> GetMatches(int id);
        List<TournamentPlayers> GetTournaments(int id);
    }
}
