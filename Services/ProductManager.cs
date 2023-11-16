using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
namespace Services

{
    public class ProductManager : IProductService
    {

        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
        }




        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(false);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);
            if (product is null)
                throw new Exception("Product not found!");
            return product;
        }

    }




}