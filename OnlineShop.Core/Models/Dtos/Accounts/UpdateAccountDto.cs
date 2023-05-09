namespace OnlineShop.Core.Models.Dtos.Accounts
{
    public class UpdateAccountDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
