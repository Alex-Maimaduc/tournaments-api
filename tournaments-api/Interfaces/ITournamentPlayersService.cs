using System.Collections.Generic;
using tournaments_api.DBModels;

namespace tournaments_api.Interfaces
{
    public interface ITournamentPlayersService
    {
        List<TournamentPlayers> Get();
        TournamentPlayers Get(int id);
        TournamentPlayers Create(TournamentPlayers tournament);
        bool Update(TournamentPlayers tournament);
        void Delete(int id);
    }
}
