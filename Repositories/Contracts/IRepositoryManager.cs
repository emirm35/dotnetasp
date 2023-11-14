namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        void Save();
        ICategoryRepository Category { get; }

    }
}