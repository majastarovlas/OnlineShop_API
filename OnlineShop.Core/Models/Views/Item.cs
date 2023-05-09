namespace OnlineShop.Core.Models.Views
{
    public class Item
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
