using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace tournaments_api.DBModels
{
    [Index(nameof(Id), IsUnique = true)]
    public class Match
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public Sport Sport { get; set; }

        [Required]
        public Gym Gym { get; set; }

        public Match()
        {
        }
    }
}
