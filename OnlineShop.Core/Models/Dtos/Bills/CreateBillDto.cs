namespace OnlineShop.Core.Models.Dtos.Bills
{
    public class CreateBillDto
    {
        public ICollection<Guid> ItemIds { get; set; } = null!;
    }
}
