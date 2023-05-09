namespace OnlineShop.Core.Models.Dtos.Items
{
    public class CreateItemDto
    {
        public Guid AccountId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
