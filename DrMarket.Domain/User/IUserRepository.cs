namespace DrMarket.Domain;

public interface IUserRepository
{
    public Task<User> Create(string nickname, string description, string? steamTradelink, string? steamNickname);
    public Task<User?> GetById(string userId);
    public Task<User?> Update(User user);
}
