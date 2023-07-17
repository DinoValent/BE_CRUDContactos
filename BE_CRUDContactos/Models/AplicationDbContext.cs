using BE_CRUDContactos.Models;
using Microsoft.EntityFrameworkCore;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(c => c.Name)
            .IsRequired();

        modelBuilder.Entity<Contact>()
            .HasOne(fc => fc.User)
            .WithMany(c => c.Contacts)
            .HasForeignKey(fc => fc.UserId);
    }
}

