namespace DrMarket.Domain;

public interface IItemRepository
{
    public Task<Item?> Get(string id);
    public Task<List<Item>> GetByUser(string userId);
    public Task<Item> Add(string userId, string gameId, string itemName, string description);
    public Task<Item> Update(Item item);
    public Task<Item?> Delete(string id);
}
