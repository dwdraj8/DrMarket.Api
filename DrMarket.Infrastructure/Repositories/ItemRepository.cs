using DrMarket.Domain;
using DrMarket.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace DrMarket.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _dbContext;

    public ItemRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Item> Add(string userId, string gameId, string itemName, string description)
    {
        var user = _dbContext.Users.First(u => u.UserId == userId);
        var game = _dbContext.Games.First(g => g.GameId == gameId);
        var item = new Item
        {
            ItemId = Guid.NewGuid().ToString(),
            Game = game,
            User = user,
            ItemName = itemName,
            Description = description,
            ItemStatus = ItemStatus.Unlisted,
            AddedOn = DateTime.UtcNow
        };

        await _dbContext.Items.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return item;
    }

    public async Task<Item?> Delete(string id)
    {
        var item = await Get(id);

        if(item != null) {
            _dbContext.Items.Remove(item);
        }
        
        await _dbContext.SaveChangesAsync();

        return item;
    }

    public async Task<Item?> Get(string id)
    {
        return await _dbContext.Items.Include(i => i.User).Include(i => i.Game).FirstOrDefaultAsync(i => i.ItemId == id);
    }

    public async Task<List<Item>> GetByUser(string userId)
    {
        return _dbContext.Items.Include(i => i.User).Include(i => i.Game).Where(i => i.User.UserId== userId).ToList();
    }

    public async Task<Item> Update(Item item)
    {
        _dbContext.Items.Update(item);
        await _dbContext.SaveChangesAsync();

        return item;
    }
}
