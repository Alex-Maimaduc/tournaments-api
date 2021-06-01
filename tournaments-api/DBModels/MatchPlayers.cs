namespace tournaments_api.DBModels
{
    public class MatchPlayers : Match
    {
        public User FirstPlayer { get; set; }

        public User SecondPlayer { get; set; }

        public TournamentPlayers Tournament { get; set; }

        public string WinnerId { get; set; }

        public int FirstPlayerScore { get; set; }

        public int SecondPlayerScore { get; set; }

        public MatchPlayers()
        {
        }
    }
}
