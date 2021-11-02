using Microsoft.EntityFrameworkCore;
using web_lab2.EntityConfigs;

namespace web_lab2.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Sage> Sages { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new SageConfig());
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}