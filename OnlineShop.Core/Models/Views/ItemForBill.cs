namespace OnlineShop.Core.Models.Views
{
    public class ItemForBill
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; } = string.Empty;
    }
}
