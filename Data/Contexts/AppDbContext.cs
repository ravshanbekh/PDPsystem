using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = BeeDb; Trusted_Connection = True;");
    }

    DbSet<User> Users { get; set; }
    DbSet<TaskUser> Tasks { get; set; }
    DbSet<Goal> Goals { get; set; }
    DbSet<JournalEntry> JournalEntries { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User Model
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        // Goal Model
        modelBuilder.Entity<Goal>()
            .HasKey(g => g.Id);
        modelBuilder.Entity<Goal>()
            .HasOne(g => g.User)
            .WithMany(u => u.Goals)
            .HasForeignKey(g => g.UserId);

        // Task Model
        modelBuilder.Entity<TaskUser>()
            .HasKey(t => t.Id);
        modelBuilder.Entity<TaskUser>()
            .HasOne(t => t.Goal)
            .WithMany(g => g.Tasks)
            .HasForeignKey(t => t.GoalId);

        // JournalEntry Model
        modelBuilder.Entity<JournalEntry>()
            .HasKey(j => j.Id);
        modelBuilder.Entity<JournalEntry>()
            .HasOne(j => j.User)
            .WithMany(u => u.JournalEntries)
            .HasForeignKey(j => j.UserId);

        // Other configurations...

        base.OnModelCreating(modelBuilder);
    }

}

