using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using tournaments_api.Enums;

namespace tournaments_api.DBModels
{
    [Index(nameof(Id), IsUnique = true)]
    public class Tournament
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ImagePath { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public Status Status { get; set; }

        public Tournament()
        {
            Status = Status.NotStarted;
        }
    }
}
