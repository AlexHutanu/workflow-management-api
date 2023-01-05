using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TicketEntity>()
            .Property("BoardForeignKey");

        modelBuilder.Entity<TicketEntity>()
            .HasOne(p => p.Board)
            .WithMany(p => p.Tickets)
            .HasForeignKey("BoardForeignKey");
    }

    public DbSet<BoardEntity> Boards { get; set; }
    public DbSet<TicketEntity> Tickets { get; set; }
    public DbSet<ActivityEntity> Activities { get; set; }
    public DbSet<UserEntity> Users { get; set; }
}

