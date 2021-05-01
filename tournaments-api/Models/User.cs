﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tournaments_api.Models
{
    public class User
    {
        [Required]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Mail { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Sport> FavoriteSports { get; set; }

        public User()
        {
            FavoriteSports = new List<Sport>();
        }
    }
}
