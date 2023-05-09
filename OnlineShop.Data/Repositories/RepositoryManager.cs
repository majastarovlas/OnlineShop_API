using OnlineShop.Core.Abstractions.Repositories;

namespace OnlineShop.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _dbContext;
        private readonly Lazy<IAccountRepository> _lazyAccountRepository;
        private readonly Lazy<IProductRepository> _lazyProductRepository;
        private readonly Lazy<IBillRepository> _lazyBillRepository;
        private readonly Lazy<IDiscountRepository> _lazyDiscountRepository;
        private readonly Lazy<IItemRepository> _lazyItemRepository;

        public RepositoryManager(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _lazyAccountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(_dbContext));
            _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(_dbContext));
            _lazyBillRepository = new Lazy<IBillRepository>(() => new BillRepository(_dbContext));
            _lazyDiscountRepository = new Lazy<IDiscountRepository>(() => new DiscountRepository(_dbContext));
            _lazyItemRepository = new Lazy<IItemRepository>(() => new ItemRepository(_dbContext));
        }

        public IAccountRepository Account => _lazyAccountRepository.Value;

        public IProductRepository Product => _lazyProductRepository.Value;

        public IBillRepository Bill => _lazyBillRepository.Value;

        public IDiscountRepository Discount => _lazyDiscountRepository.Value;

        public IItemRepository Item => _lazyItemRepository.Value;

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
