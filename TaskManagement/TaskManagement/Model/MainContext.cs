using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskManagement.Model
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options):base(options)
        {

            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasOne(x => x.Login).WithOne(x => x.User).HasForeignKey("Id");
            /////
            modelBuilder.Entity<Login>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

    }
}
