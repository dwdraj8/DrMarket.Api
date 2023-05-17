using DrMarket.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DrMarket.Api.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddGameAsync(string name, string description)
        {
            var game = await _gameRepository.Add(name, description);

            return Ok(game);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameRepository.GetAll();

            return games is null ? BadRequest() : Ok(games);
        }
    }
}