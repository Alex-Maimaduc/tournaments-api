using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tournaments_api.DBModels
{
    public class User
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Mail { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Description { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ImagePath { get; set; }

        public List<Sport> FavoriteSports { get; set; }

        [InverseProperty("Members")]
        public Gym Gym { get; set; }

        [InverseProperty("Players")]
        public Team Team { get; set; }

        public User()
        {
            FavoriteSports = new List<Sport>();
        }
    }
}
