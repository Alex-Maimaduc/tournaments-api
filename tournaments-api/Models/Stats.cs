namespace tournaments_api.Models
{
    public class Stats
    {
        public int WonMatches { get; set; }
        public int LostMatches { get; set; }
        public int Score { get; set; }
        public int WonTournaments { get; set; }
        public int LostTournaments { get; set; }
        public int TotalMatches { get; set; }

        public Stats()
        {
            
        }
    }
}
