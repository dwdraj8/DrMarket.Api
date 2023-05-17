namespace DrMarket.Domain;

public interface IListingRepository
{
    public Task<Listing?> Get(string id);
    public Task<List<Listing>> GetByUser(string userId);
    public Task<List<Listing>> GetAll();
    public Task<Listing> Add(string itemId, double initialPrice, double buyNowPrice, int durationInHours);
    public Task<Listing> Update(Listing listing);
    public Task<Listing?> Delete(string id);
}
