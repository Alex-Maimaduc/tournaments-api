﻿namespace tournaments_api.Models
{
    public class MatchTeams:Match
    {
        public Team FirstTeam { get; set; }

        public Team SecondTeam { get; set; }

        public TournamentTeams Tournament { get; set; }

        public MatchTeams()
        {
        }
    }
}
