using OnlineShop.Core.Abstractions.Repositories;

namespace OnlineShop.Application
{
    public abstract class BaseService
    {
        protected readonly IRepositoryManager RepositoryManager;

        protected BaseService(IRepositoryManager repositoryManager)
        {
            RepositoryManager = repositoryManager;
        }
    }
}
