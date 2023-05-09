namespace OnlineShop.Core.Abstractions.Repositories
{
    public interface IRepositoryManager
    {
        IAccountRepository Account { get; }
        IProductRepository Product { get; }
        IBillRepository Bill { get; }
        IDiscountRepository Discount { get; }
        IItemRepository Item { get; }
        Task SaveAsync();
    }
}
