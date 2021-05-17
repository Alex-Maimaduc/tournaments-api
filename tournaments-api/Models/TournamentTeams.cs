using System.Collections.Generic;

namespace tournaments_api.Models
{
    public class TournamentTeams : Tournament
    {
        public List<MatchTeams> Matches { get; set; }

        public TournamentTeams()
        {
        }
    }
}
