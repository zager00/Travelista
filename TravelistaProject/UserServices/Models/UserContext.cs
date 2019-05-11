using Microsoft.EntityFrameworkCore;

namespace UserServices.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Username);
        }

        public DbSet<User>Users { get; set; }
        public DbSet<UserAdditionalInfo> UserAdditionalInfo { get; set; }
        public DbSet<UserFiles> UserFiles { get; set; }
        public DbSet<UserBookingDetails> UserBookingDetails { get; set; }

    }
}
