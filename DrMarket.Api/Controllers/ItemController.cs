using DrMarket.Application.Items;
using DrMarket.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DrMarket.Api.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddItemAsync(AddItemDto addItemDto)
        {
            var user = await _itemRepository.Add(addItemDto.UserId, addItemDto.GameId, addItemDto.ItemName, addItemDto.Description);

            return Ok(user);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetItemByIdAsync(string itemId)
        {
            var item = await _itemRepository.Get(itemId);

            return item is null ? BadRequest() : Ok(item);
        }

        [HttpGet("item-by-user")]
        public async Task<IActionResult> GetItemsForUserAsync(string userId)
        {
            var item = await _itemRepository.GetByUser(userId);

            return item is null ? BadRequest() : Ok(item);
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteItem(string itemId)
        {
            var item = await _itemRepository.Delete(itemId);

            return item is null ? BadRequest() : Ok(item);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateItem(Item item)
        {
            var updatedItem = await _itemRepository.Update(item);

            return item is null ? BadRequest() : Ok(updatedItem);
        }
    }
}
