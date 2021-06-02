namespace tournaments_api.DBModels
{
    public class MatchTeams:Match
    {
        public Team FirstTeam { get; set; }

        public Team SecondTeam { get; set; }

        public TournamentTeams Tournament { get; set; }

        public int WinnerId { get; set; }

        public MatchTeams()
        {
        }
    }
}
