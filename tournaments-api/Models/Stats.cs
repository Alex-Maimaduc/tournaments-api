namespace tournaments_api.Models
{
    public class Stats
    {
        public int WonMatchs { get; set; }
        public int LostMatches { get; set; }
        public int Score { get; set; }
        public int WonTournaments { get; set; }
        public int LostTournaments { get; set; }


        public Stats()
        {
            
        }
    }
}
