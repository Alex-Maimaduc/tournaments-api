using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using tournaments_api.Models;

namespace tournaments_api.DBModels
{
    [Index(nameof(Id), IsUnique = true)]
    public class Gym
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int Number { get; set; }

        public string ImagePath { get; set; }

        public bool IsDeleted { get; set; }

        public User Owner { get; set; }

        public List<User> Members { get; set; }

        public List<MatchPlayers> MatchesPlayers { get; set; }

        public List<MatchTeams> MatchesTeams { get; set; }

        public List<TournamentPlayers> TournamentsPlayers { get; set; }

        public List<TournamentTeams> TournamentsTeams { get; set; }

        public Gym()
        {
            MatchesPlayers = new List<MatchPlayers>();
            MatchesTeams = new List<MatchTeams>();
            TournamentsPlayers = new List<TournamentPlayers>();
            TournamentsTeams = new List<TournamentTeams>();
        }
    }
}
