﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace tournaments_api.Models
{
    [Index(nameof(Id), IsUnique = true)]
    public class Club
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Team> Teams { get; set; }

        public Club()
        {
        }
    }
}
