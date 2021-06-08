using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace tournaments_api.DBModels
{
    [Index(nameof(Id), IsUnique = true)]
    public class Sport
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public List<User> Users{get;set;}

        public List<Team> Teams { get; set; }

        public Sport()
        {
            Users = new List<User>();
            Teams = new List<Team>();
        }
    }
}
