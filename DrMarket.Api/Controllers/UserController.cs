using DrMarket.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DrMarket.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateUserAsync(string nickname, string description, string? steamTradelink, string? steamNickname)
        {
            var user = await _userRepository.Create(nickname, description, steamTradelink, steamNickname);

            return Ok(user);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUserByIdAsync(string userId)
        {
            var user = await _userRepository.GetById(userId);

            return user is null ? BadRequest() : Ok(user);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateUserAsync([FromBody]User user)
        {
            var updatedUser = await _userRepository.Update(user);

            return updatedUser is null ? BadRequest() : Ok(updatedUser);
        }
    }
}
