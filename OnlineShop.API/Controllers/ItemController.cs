using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Abstractions.Services;
using OnlineShop.Core.Models.Dtos.Items;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("/api/item")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("get-all-items")]
        public async Task<IActionResult> GetAllItems()
        {
            var result = await _itemService.GetAllItemsAsync();
            return Ok(result);
        }

        [HttpGet("get-item-by-id/{id}")]
        public async Task<IActionResult> GetItemById(Guid id)
        {
            var result = await _itemService.GetItemByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("create-item")]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemDto itemDto)
        {
            var result = await _itemService.CreateItemAsync(itemDto);
            return Ok(result);
        }

        [HttpPut("update-item")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateItemDto itemDto)
        {
            var result = await _itemService.UpdateItemAsync(itemDto);
            return Ok(result);
        }

        [HttpPut("remove-item/{id}")]
        public async Task<IActionResult> RemoveItem(Guid id)
        {
            await _itemService.RemoveItemAsync(id);
            return Ok();
        }
    }
}
