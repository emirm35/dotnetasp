using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{

    //* IproRepo => IRepoBase'i devralıyor
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        IQueryable<Product> GetShowcaseProducts(bool trackChanges);

        Product? GetOneProduct(int id, bool trackChanges);
        void CreateOneProduct(Product product);
        void DeleteOneProduct(Product product);
        void UpdateOneProduct(Product entity);
    }
}