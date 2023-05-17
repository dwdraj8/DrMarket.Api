using DrMarket.Domain;
using Microsoft.EntityFrameworkCore;

namespace DrMarket.Infrastructure.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Listing> Listings { get; set; }
}
