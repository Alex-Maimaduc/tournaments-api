using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tournaments_api.DBModels
{
    [Index(nameof(Id), IsUnique = true)]
    public class Team
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public string ImagePath { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public Sport Sport { get; set; }

        public User Owner { get; set; }

        [InverseProperty("Team")]
        public List<User> Players { get; set; }

        public Team()
        {
            IsDeleted = false;
            Players = new List<User>();
        }
    }
}
