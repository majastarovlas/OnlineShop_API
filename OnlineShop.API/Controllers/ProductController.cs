using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Abstractions.Services;
using OnlineShop.Core.Models.Dtos.Products;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("/api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get-all-products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpGet("get-product-by-id/{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {
            var result = await _productService.CreateProductAsync(productDto);
            return Ok(result);
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto productDto)
        {
            var result = await _productService.UpdateProductAsync(productDto);
            return Ok(result);
        }

        [HttpPut("remove-product/{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            await _productService.RemoveProductAsync(id);
            return Ok();
        }
    }
}
