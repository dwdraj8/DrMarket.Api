namespace DrMarket.Domain;

public class User
{
    public string UserId { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string? SteamNickname { get; set; }
    public string? SteamTradelink { get; set; }
    public string Description { get; set; } = null!;
    public DateTime MemberSince { get; set; }
    public double ReputationPoints { get; set; }
}
