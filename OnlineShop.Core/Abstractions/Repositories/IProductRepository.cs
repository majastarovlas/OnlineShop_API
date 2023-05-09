using OnlineShop.Core.Models.Entities;

namespace OnlineShop.Core.Abstractions.Repositories
{
    public interface IProductRepository
    {
        IQueryable<ProductEntity> GetAllProducts(bool trackChanges = false);
        Task<ProductEntity?> GetProductByIdAsync(Guid id, bool trackChanges = false);
        void CreateProduct(ProductEntity product);
    }
}
