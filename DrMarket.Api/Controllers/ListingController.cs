using DrMarket.Application.Items;
using DrMarket.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DrMarket.Api.Controllers
{
    [Route("api/listing")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly IListingRepository _listingRepository;
        public ListingController(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddListingAsync(string itemId, double initialPrice, double buyNowPrice, int durationInHours)
        {
            var listing = await _listingRepository.Add(itemId, initialPrice, buyNowPrice, durationInHours);

            return Ok(listing);
        }

        [HttpGet("listing-by-id")]
        public async Task<IActionResult> GetListingByIdAsync(string listingId)
        {
            var listing = await _listingRepository.Get(listingId);

            return listing is null ? BadRequest() : Ok(listing);
        }

        [HttpGet("listings-by-user")]
        public async Task<IActionResult> GetListingsForUserAsync(string userId)
        {
            var listings = await _listingRepository.GetByUser(userId);

            return listings is null ? BadRequest() : Ok(listings);
        }

        [HttpGet("listings-all")]
        public async Task<IActionResult> GetAllListingsAsync()
        {
            var listings = await _listingRepository.GetAll();

            return listings is null ? BadRequest() : Ok(listings);
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteItem(string listingId)
        {
            var listing = await _listingRepository.Delete(listingId);

            return listing is null ? BadRequest() : Ok(listingId);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateItem(Listing listing)
        {
            var updatedItem = await _listingRepository.Update(listing);

            return listing is null ? BadRequest() : Ok(updatedItem);
        }
    }
}
