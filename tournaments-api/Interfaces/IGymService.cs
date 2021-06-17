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
        bool Delete(int id);
        List<MatchPlayers> GetMatches(int id,Status status, Period period,int sportId);
        List<MatchTeams> GetMatchesTeams(int id,Status status, Period period, int sportId);
        List<TournamentPlayers> GetTournaments(int id, Status status, Period period, int sportId);
        List<TournamentTeams> GetTournamentsTeams(int id, Status status, Period period, int sportId);
    }
}
