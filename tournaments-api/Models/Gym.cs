using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace tournaments_api.Models
{
    [Index(nameof(Id), IsUnique = true)]
    public class Gym
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public Adress adress { get; set; }

        public List<MatchPlayers> MatchesPlayers { get; set; }

        public List<MatchTeams> MatchesTeams { get; set; }

        public List<TournamentPlayers> TournamentsPlayers { get; set; }

        public List<TournamentTeams> TournamentsTeams { get; set; }

        public Gym()
        {
        }
    }
}
