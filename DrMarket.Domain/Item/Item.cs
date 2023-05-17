namespace DrMarket.Domain;

public class Item
{
    public string ItemId { get; set; } = null!;
    public string ItemName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime AddedOn { get; set; }
    public ItemStatus ItemStatus{ get; set; }
    public virtual User User { get; set; } = null!;
    public virtual Game Game { get; set; } = null!;
}

public enum ItemStatus
{
    Unlisted,
    Listed,
    Sold
}
