using Microsoft.EntityFrameworkCore;
using tournements.Data;

namespace tournaments.Repository
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user=>{
                user.HasIndex(e => e.Mail).IsUnique(true);
            });
                
        }

        public DbSet<User> Users { get; set; }

    }
}
