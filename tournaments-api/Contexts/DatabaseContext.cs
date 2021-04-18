using Microsoft.EntityFrameworkCore;
using tournaments_api.Models;

namespace tournaments_api.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.HasIndex(e => e.Mail).IsUnique(true);
            });

            modelBuilder.Entity<Sport>(sport =>
            {
            });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Sport> Sports { get; set; }
    }
}
