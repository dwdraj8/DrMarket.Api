namespace DrMarket.Domain;

public interface IGameRepository
{
    public Task<Game> Add(string name, string description);
    public Task<List<Game>> GetAll();
}
