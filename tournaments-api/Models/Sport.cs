using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace tournaments_api.Models
{
    [Index(nameof(Id),IsUnique =true)]
    public class Sport
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Sport()
        {

        }
    }
}
