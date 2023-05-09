using OnlineShop.Core.Models.Views;

namespace OnlineShop.Core.Models.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public DiscountEntity Discount { get; set; } = null!;
        public ICollection<ItemEntity> Items { get; set; } = null!;

        public Product ToViewModel()
        {
            return new Product
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Price = Price
            };
        }
    }
}
