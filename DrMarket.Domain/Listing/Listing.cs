namespace DrMarket.Domain;

public class Listing
{
    public string ListingId { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public double InitialPrice { get; set; }
    public double CurrentPrice { get; set; }
    public double BuyNowPrice { get; set; }
    public ListingStatus ListingStatus { get; set; }
    public double? SoldFor { get; set; }
    public virtual Item Item { get; set; } = null!;
}

public enum ListingStatus
{
    Active,
    Expired,
    Finished
}
