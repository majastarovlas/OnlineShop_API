using OnlineShop.Core.Models.Dtos.Products;
using OnlineShop.Core.Models.Views;

namespace OnlineShop.Core.Abstractions.Services
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(Guid id);
        Task<Product> CreateProductAsync(CreateProductDto productDto);
        Task<Product> UpdateProductAsync(UpdateProductDto productDto);
        Task RemoveProductAsync(Guid id);
    }
}
