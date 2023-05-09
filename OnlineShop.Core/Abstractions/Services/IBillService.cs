using OnlineShop.Core.Models.Dtos.Bills;
using OnlineShop.Core.Models.Views;

namespace OnlineShop.Core.Abstractions.Services
{
    public interface IBillService
    {
        Task<Bill> CreateBillAsync(CreateBillDto billDto);
        Task<ICollection<Bill>> GetAllBillsAsync();
    }
}
