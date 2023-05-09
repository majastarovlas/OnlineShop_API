using OnlineShop.Core.Models.Views;

namespace OnlineShop.Core.Models.Entities
{
    public class AccountEntity : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public ICollection<ItemEntity> Items { get; set; } = null!;

        public Account ToViewModel()
        {
            return new Account
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email
            };
        }
    }
}
