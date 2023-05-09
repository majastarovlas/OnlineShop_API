namespace OnlineShop.Core.Models.Dtos.Items
{
    public class UpdateItemDto
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
