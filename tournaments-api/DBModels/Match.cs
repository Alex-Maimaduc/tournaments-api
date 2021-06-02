using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using tournaments_api.Enums;

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

        public int FirstScore { get; set; }

        public int SecondScore { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public Status Status { get; set; }

        public Sport Sport { get; set; }

        public Gym Gym { get; set; }

        public Match()
        {
            Status = Status.NotStarted;
        }
    }
}
