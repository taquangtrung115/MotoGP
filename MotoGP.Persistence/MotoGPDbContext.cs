using Microsoft.EntityFrameworkCore;
using MotoGP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoGP.Persistence;

public class MotoGPDbContext : DbContext
{
    public MotoGPDbContext(DbContextOptions<MotoGPDbContext> options) : base(options) { }

    public DbSet<News> News => Set<News>();
    public DbSet<Video> Videos => Set<Video>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Rider> Riders => Set<Rider>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<RaceEvent> RaceEvents => Set<RaceEvent>();
    public DbSet<RaceResult> RaceResults => Set<RaceResult>();
    public DbSet<SeasonStanding> SeasonStandings => Set<SeasonStanding>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // thêm Fluent API nếu cần

    //    modelBuilder.Entity<News>().HasData(
    //    new News
    //    {
    //        Id = Guid.NewGuid(),
    //        Title = "Marc Marquez returns to top form",
    //        Content = "After a long recovery, Marc is finally back...",
    //        PublishedAt = DateTime.UtcNow.AddDays(-1),
    //        ImageUrl = "https://cdn.motogp.com/images/news1.jpg"
    //    },
    //    new News
    //    {
    //        Id = Guid.NewGuid(),
    //        Title = "MotoGP 2025 calendar announced",
    //        Content = "The official race calendar for the 2025 season is here.",
    //        PublishedAt = DateTime.UtcNow.AddDays(-5),
    //        ImageUrl = "https://cdn.motogp.com/images/news2.jpg"
    //    }
    //);

    //    modelBuilder.Entity<Video>().HasData(
    //        new Video
    //        {
    //            Id = Guid.NewGuid(),
    //            Title = "Best Overtakes of 2024",
    //            Url = "https://youtube.com/watch?v=abc123",
    //            Thumbnail = "https://cdn.motogp.com/videos/thumb1.jpg",
    //            PublishedAt = DateTime.UtcNow.AddDays(-2)
    //        },
    //        new Video
    //        {
    //            Id = Guid.NewGuid(),
    //            Title = "Top Crashes – Not for the faint-hearted",
    //            Url = "https://youtube.com/watch?v=def456",
    //            Thumbnail = "https://cdn.motogp.com/videos/thumb2.jpg",
    //            PublishedAt = DateTime.UtcNow.AddDays(-3)
    //        }
    //    );
    }
}