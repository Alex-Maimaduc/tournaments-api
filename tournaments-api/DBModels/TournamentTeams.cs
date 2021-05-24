using System.Collections.Generic;

namespace tournaments_api.DBModels
{
    public class TournamentTeams : Tournament
    {
        public List<MatchTeams> Matches { get; set; }

        public TournamentTeams()
        {
        }
    }
}
