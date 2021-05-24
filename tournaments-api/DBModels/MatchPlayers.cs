namespace tournaments_api.DBModels
{
    public class MatchPlayers : Match
    {
        public User FirstPlayer { get; set; }

        public User SecondPlayer { get; set; }

        public TournamentPlayers Tournament { get; set; }

        public MatchPlayers()
        {
        }
    }
}
