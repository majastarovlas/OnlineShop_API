namespace OnlineShop.Core.Models.Dtos.Products
{
    public class CreateDiscountDto
    {
        public int Value { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
