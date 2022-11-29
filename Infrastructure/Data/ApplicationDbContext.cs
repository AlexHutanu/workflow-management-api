using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WorkflowManagement.Data;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Board> Boards { get; set; }
    public DbSet<BugTicket> BugTicket { get; set; }
    public DbSet<Activity> Activity { get; set; }
    public DbSet<User> User { get; set; }
}

