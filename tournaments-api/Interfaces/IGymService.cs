using System.Collections.Generic;
using tournaments_api.DBModels;
using tournaments_api.Enums;

namespace tournaments_api.Interfaces
{
    public interface IGymService
    {
        IEnumerable<Gym> Get();
        Gym Get(int id);
        Gym Create(Gym gym);
        bool Update(Gym gym);
        void Delete(int id);
        List<MatchPlayers> GetMatches(int id,Status status, Period period);
        List<TournamentPlayers> GetTournaments(int id, Status status, Period period);
    }
}
