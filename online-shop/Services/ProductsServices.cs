using online_shop.Models;
using online_shop.Repositories;

namespace online_shop.Services
{
    public class ProductsServices
    {
        private ProductRepository repository;

        public ProductsServices()
        {
            repository = new ProductRepository();
        }

        public bool isProduct(string name)
        {
            return repository.isProduct(name);
        }

        public Product GetProduct(string name)
        {
            if (isProduct(name) == false)
                return null;

            return repository.getByName(name);
        }


    }
}