using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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

        public Tournament()
        {
        }
    }
}
