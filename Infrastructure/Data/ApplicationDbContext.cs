using Domain.Entities;
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
            .Property("BoardId");

        modelBuilder.Entity<TicketEntity>()
            .Property("UserId");

        modelBuilder.Entity<BoardEntity>()
            .Property("UserId");

            

        modelBuilder.Entity<TicketEntity>()
            .HasOne(p => p.Board)
            .WithMany(p => p.Tickets)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey("BoardId");

        modelBuilder.Entity<TicketEntity>()
            .HasOne(p => p.User)
            .WithMany(p => p.Tickets)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey("UserId");

        modelBuilder.Entity<BoardEntity>()
            .HasOne(p => p.User)
            .WithMany(p => p.Boards)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey("UserId");


        modelBuilder.Entity<UserEntity>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
    }

    public DbSet<BoardEntity> Boards { get; set; }
    public DbSet<TicketEntity> Tickets { get; set; }
    public DbSet<ActivityEntity> Activities { get; set; }
    public DbSet<UserEntity> Users { get; set; }
}

