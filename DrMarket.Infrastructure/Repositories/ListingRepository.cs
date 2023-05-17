using DrMarket.Domain;
using DrMarket.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace DrMarket.Infrastructure.Repositories;

public class ListingRepository : IListingRepository
{
    private readonly AppDbContext _dbContext;

    public ListingRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Listing> Add(string itemId, double initialPrice, double buyNowPrice, int durationInHours)
    {
        var item = _dbContext.Items.Include(i => i.User).Include(i => i.Game).First(i => i.ItemId == itemId);

        var listing = new Listing
        {
            ListingId = Guid.NewGuid().ToString(),
            ListingStatus = ListingStatus.Active,
            BuyNowPrice = buyNowPrice,
            InitialPrice = initialPrice,
            CurrentPrice = initialPrice,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddHours(durationInHours),
            Item = item,
        };

        await _dbContext.Listings.AddAsync(listing);
        await _dbContext.SaveChangesAsync();

        return listing;
    }

    public async Task<Listing?> Delete(string id)
    {
        var listing = await Get(id);

        if (listing != null)
        {
            _dbContext.Listings.Remove(listing);
        }

        await _dbContext.SaveChangesAsync();

        return listing;
    }

    public async Task<Listing?> Get(string id)
    {
        return _dbContext.Listings.Include(l => l.Item.User).Include(l => l.Item.Game).FirstOrDefault(l => l.ListingId == id);
    }

    public async Task<List<Listing>> GetAll()
    {
        return _dbContext.Listings.Include(l => l.Item.User).Include(l => l.Item.Game).ToList();
    }

    public async Task<List<Listing>> GetByUser(string userId)
    {
        return _dbContext.Listings.Include(l => l.Item.User).Include(l => l.Item.Game).Where(l => l.Item.User.UserId == userId).ToList();
    }

    public async Task<Listing> Update(Listing listing)
    {
        _dbContext.Listings.Update(listing);
        await _dbContext.SaveChangesAsync();

        return listing;
    }
}
