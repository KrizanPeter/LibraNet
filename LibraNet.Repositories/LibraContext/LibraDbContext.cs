using LibraNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace LibraNet.Domain.LibraContext
{
    public class LibraDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=library.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Borrowing> Borrowing { get; set; }
    }
}
