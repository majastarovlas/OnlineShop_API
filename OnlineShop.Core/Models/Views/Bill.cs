namespace OnlineShop.Core.Models.Views
{
    public class Bill
    {
        public Guid Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<ItemForBill> Items { get; set; } = null!;
    }
}
