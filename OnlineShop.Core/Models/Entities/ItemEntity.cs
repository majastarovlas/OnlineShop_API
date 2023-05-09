using OnlineShop.Core.Models.Views;

namespace OnlineShop.Core.Models.Entities
{
    public class ItemEntity : BaseEntity
    {
        public int Quantity { get; set; }
        public Guid AccountId { get; set; }
        public AccountEntity Account { get; set; } = null!;
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;
        public Guid? BillId { get; set; }
        public BillEntity? Bill { get; set; }

        public Item ToViewModel()
        {
            return new Item
            {
                Id = Id,
                AccountName = Account.FirstName + " " + Account.LastName,
                ProductName = Product.Name,
                Quantity = Quantity
            };
        }
    }
}
