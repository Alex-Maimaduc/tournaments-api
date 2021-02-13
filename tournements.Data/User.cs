using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace tournements.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }

        public User(string mail, string password)
        {
            Mail = mail;
            Password = password;
        }

        public User()
        {
        }
    }
}
