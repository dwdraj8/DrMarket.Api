using DrMarket.Domain;
using DrMarket.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace DrMarket.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> Create(string nickname, string description, string? steamTradelink, string? steamNickname)
    {
        var user = new User
        {
            UserId = Guid.NewGuid().ToString(),
            Username = nickname,
            Description = description,
            SteamTradelink = steamTradelink,
            SteamNickname = steamNickname,
            ReputationPoints = 0,
            MemberSince = DateTime.UtcNow,
        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User?> GetById(string userId)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public async Task<User?> Update(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }
}
