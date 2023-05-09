namespace OnlineShop.Core.Models.Entities
{
    public class DiscountEntity : BaseEntity
    {
        public int Value { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;
    }
}
