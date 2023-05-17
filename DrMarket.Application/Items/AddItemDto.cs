using DrMarket.Domain;

namespace DrMarket.Application.Items;

public class AddItemDto
{
    public string UserId { get; set; } = null!;
    public string GameId { get; set; } = null!;
    public string ItemName { get; set; } = null!;
    public string Description { get; set; } = null!;
}
