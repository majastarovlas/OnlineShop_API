namespace OnlineShop.Core.Models.Dtos.Products
{
    public class UpdateDiscountDto
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
