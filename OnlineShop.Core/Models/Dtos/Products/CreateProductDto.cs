namespace OnlineShop.Core.Models.Dtos.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public CreateDiscountDto? Discount { get; set; }
    }
}
