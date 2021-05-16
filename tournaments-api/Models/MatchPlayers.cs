namespace tournaments_api.Models
{
    public class MatchPlayers:Match
    {
        public User FirstPlayer { get; set; }

        public User SecondPlyaer { get; set; }

        public MatchPlayers()
        {
        }
    }
}
