using DrMarket.Domain;
using DrMarket.Infrastructure.Db;

namespace DrMarket.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _dbContext;
    public GameRepository(AppDbContext dbContext)
    {  
        _dbContext = dbContext;
    }
    public async Task<Game> Add(string name, string description)
    {
        var game = new Game
        {
            GameId = Guid.NewGuid().ToString(),
            GameName = name,
            Description = description
        };

        await _dbContext.Games.AddAsync(game);
        await _dbContext.SaveChangesAsync();
        return game;
    }

    public Task<List<Game>> GetAll()
    {
        var games = _dbContext.Games;

        return Task.FromResult(games.ToList());
    }
}
