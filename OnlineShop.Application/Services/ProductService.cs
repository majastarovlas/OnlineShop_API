using Microsoft.EntityFrameworkCore;
using OnlineShop.Common.Exceptions;
using OnlineShop.Core.Abstractions.Repositories;
using OnlineShop.Core.Abstractions.Services;
using OnlineShop.Core.Models.Dtos.Products;
using OnlineShop.Core.Models.Entities;
using OnlineShop.Core.Models.Views;

namespace OnlineShop.Application.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }

        public async Task<ICollection<Product>> GetAllProductsAsync()
        {
            var queryable = RepositoryManager.Product
                .GetAllProducts()
                .Select(x => x.ToViewModel());

            var result = await queryable.ToListAsync();

            return result;
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            var entity = await RepositoryManager.Product.GetProductByIdAsync(id);

            if (entity == null)
            {
                throw new NotFoundException("Product not found by id.");
            }

            var result = entity.ToViewModel();

            return result;
        }

        public async Task<Product> CreateProductAsync(CreateProductDto productDto)
        {
            var entity = new ProductEntity
            {
                Id = Guid.NewGuid(),

                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price
            };

            if (productDto.Discount != null)
            {
                var discountEntity = new DiscountEntity
                {
                    Id = Guid.NewGuid(),

                    Value = productDto.Discount.Value,
                    ExpiryDate = productDto.Discount.ExpiryDate,

                    ProductId = entity.Id
                };

                RepositoryManager.Discount.CreateDiscount(discountEntity);
            }

            RepositoryManager.Product.CreateProduct(entity);

            await RepositoryManager.SaveAsync();

            var created = await RepositoryManager.Product.GetProductByIdAsync(entity.Id);

            if (created == null)
            {
                throw new NotFoundException("Product not found by id.");
            }

            var result = created.ToViewModel();

            return result;
        }

        public async Task<Product> UpdateProductAsync(UpdateProductDto productDto)
        {
            var entity = await RepositoryManager.Product.GetProductByIdAsync(productDto.Id, trackChanges: true);

            if (entity == null)
            {
                throw new NotFoundException("Product not found by id.");
            }

            entity.Name = productDto.Name;
            entity.Description = productDto.Description;
            entity.Price = productDto.Price;

            if (productDto.Discount != null)
            {
                if (productDto.Discount.Id == Guid.Empty)
                {
                    // Create

                    var discountEntity = new DiscountEntity
                    {
                        Id = Guid.NewGuid(),

                        Value = productDto.Discount.Value,
                        ExpiryDate = productDto.Discount.ExpiryDate,

                        ProductId = entity.Id
                    };

                    RepositoryManager.Discount.CreateDiscount(discountEntity);
                }
                else
                {
                    // Update 

                    var discountEntity = await RepositoryManager.Discount.GetDiscountByIdAsync(productDto.Discount.Id, trackChanges: true);

                    if (discountEntity == null)
                    {
                        throw new NotFoundException("Discount not found by id.");
                    }

                    discountEntity.Value = productDto.Discount.Value;
                    discountEntity.ExpiryDate = productDto.Discount.ExpiryDate;
                }
            }
            else
            {
                // Remove

                var discountEntity = await RepositoryManager.Discount.GetDiscountByProductIdAsync(productDto.Id, trackChanges: true);

                if (discountEntity == null)
                {
                    throw new NotFoundException("Discount not found by id.");
                }

                discountEntity.IsDeleted = true;
            }

            await RepositoryManager.SaveAsync();

            var updated = await RepositoryManager.Product.GetProductByIdAsync(entity.Id);

            if (updated == null)
            {
                throw new NotFoundException("Product not found by id.");
            }

            var result = updated.ToViewModel();

            return result;
        }

        public async Task RemoveProductAsync(Guid id)
        {
            var entity = await RepositoryManager.Product.GetProductByIdAsync(id, trackChanges: true);

            if (entity == null)
            {
                throw new NotFoundException("Product not found by id.");
            }

            entity.IsDeleted = true;

            await RepositoryManager.SaveAsync();
        }
    }
}
