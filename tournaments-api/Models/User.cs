using System;
using System.ComponentModel.DataAnnotations;

namespace tournements.Data
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

        public User(string id, string mail)
        {
            Id = id;
            Mail = mail;
        }

        public User()
        {
        }
    }
}
