using si730ebu20201c334.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using si730ebu20201c334.API.Loyalty.Domain.Models;

namespace si730ebu20201c334.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Reward> Rewards { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //Reward Configuration
        
        builder.Entity<Reward>().ToTable("Rewards");
        builder.Entity<Reward>().HasKey(p => p.Id);
        builder.Entity<Reward>().Property(p => p.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reward>().Property(p => p.FleetId)
            .IsRequired();
        builder.Entity<Reward>().Property(p => p.Name)
            .IsRequired();
        builder.Entity<Reward>().Property(p => p.Description)
            .IsRequired();
        builder.Entity<Reward>().Property(p => p.Score)
            .IsRequired();
        
        builder.UseSnakeCaseNamingConvention();

    }
}