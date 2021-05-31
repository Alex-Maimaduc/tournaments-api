using System.Collections.Generic;
using tournaments_api.DBModels;

namespace tournaments_api.Interfaces
{
    public interface IUserService
    {
        List<User> Get();

        User Get(string id);

        User Create(User user);

        bool Update(User user);

        void Delete(string id);

        bool AddSports(string id, List<int> sports);

        Team GetTeam(string id);

        List<Sport> GetFavoriteSports(string id);

        bool RemoveFavoriteSport(string id,int sportId);

        List<MatchPlayers> GetMatches(string id);

        List<TournamentPlayers> GetTournaments(string id);

        int GymOwner(string id);
    }
}
