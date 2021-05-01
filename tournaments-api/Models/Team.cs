using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace tournaments_api.Models
{
    [Index(nameof(Id), IsUnique = true)]
    public class Team
    {
        [Required]
        public int Id { get; set; }

        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public User Owner { get; set; }

        public List<User> Players { get; set; }

        public Team()
        {
            Players = new List<User>();
        }
    }
}
