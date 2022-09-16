

using Microsoft.EntityFrameworkCore;

namespace src.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

        public ModelBuilder OnModelCreation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WinWire>().ToTable("WinWire");
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<WinWire>().HasKey(x => x.Id);
            modelBuilder.Entity<Contact>().HasKey(x => x.ContactId);
            return modelBuilder;
        }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<WinWire> WinWire { get; set; }
    }

}