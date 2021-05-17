using System.Collections.Generic;

namespace tournaments_api.Models
{
    public class TournamentPlayers : Tournament
    {
        public List<MatchPlayers> Matches { get; set; }

        public TournamentPlayers()
        {
        }
    }
}
