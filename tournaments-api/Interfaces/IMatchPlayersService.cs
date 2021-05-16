using System.Collections.Generic;
using tournaments_api.Models;

namespace tournaments_api.Interfaces
{
    public interface IMatchPlayersService
    {
        List<MatchPlayers> Get();
        MatchPlayers Get(int id);
        MatchPlayers Create(MatchPlayers match);
        bool Update(MatchPlayers match);
        void Delete(int id);
    }
}
