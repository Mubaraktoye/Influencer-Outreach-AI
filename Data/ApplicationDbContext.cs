using Influencer_Outreach_AI.Models;
using Microsoft.EntityFrameworkCore;

namespace Influencer_Outreach_AI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Influencer> Influencers { get; set; }
    public DbSet<OutreachMessage> OutreachMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Influencer>()
            .HasMany(i => i.OutreachMessages)
            .WithOne(m => m.Influencer)
            .HasForeignKey(m => m.InfluencerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OutreachMessage>()
            .Property(m => m.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Influencer>()
            .Property(i => i.Status)
            .HasConversion<string>();
    }
}