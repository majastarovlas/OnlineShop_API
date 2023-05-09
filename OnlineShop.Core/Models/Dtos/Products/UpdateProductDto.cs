namespace OnlineShop.Core.Models.Dtos.Products
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public UpdateDiscountDto? Discount { get; set; }
    }
}
