using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Models.Entities;

namespace OnlineShop.Data.Repositories
{
    public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<ProductEntity> GetAllProducts(bool trackChanges)
            => FindAll(trackChanges).Where(x => !x.IsDeleted);

        public async Task<ProductEntity?> GetProductByIdAsync(Guid id, bool trackChanges)
            => await FindByCondition(x => x.Id == id && !x.IsDeleted, trackChanges).FirstOrDefaultAsync();

        public void CreateProduct(ProductEntity product) => Create(product);
    }
}
