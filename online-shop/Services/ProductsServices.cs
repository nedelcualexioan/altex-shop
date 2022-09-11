using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using online_shop.Exceptions;
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
        public ProductsServices(string database)
        {
            repository = new ProductRepository(database);
        }

        public Product GetProduct(string name)
        {
            if (repository.getAll().Exists(p => p.Name.Equals(name)))
            {
                return repository.getByName(name);
            }

            throw new ObjectNotFoundException();
        }

        public Product GetProduct(int id)
        {
            if (repository.getAll().Exists(p => p.Id.Equals(id)))
            {
                return repository.getById(id);
            }

            throw new ObjectNotFoundException();
        }

        public void deleteAll()
        {
            string sql = "DELETE FROM products";

        }

        public List<Product> getRandom(int count)
        {
            if (repository.getRandom(count).Count < count)
            {
                throw new NotEnoughObjectsException();
            }

            return repository.getRandom(count);
        }

        public List<Product> getByCategory(int category)
        {
            if (repository.getByCategory(category).Count == 0)
            {
                throw new EntryDatabaseException();
            }

            return repository.getByCategory(category);
        }

        public List<Product> GetCategorySortBy(int category_id, string sort)
        {
            if (repository.getCategorySortBy(category_id, sort).Count == 0)
            {
                throw new EntryDatabaseException();
            }

            return repository.getCategorySortBy(category_id, sort);
        }

        public List<Product> getAllProducts()
        {
            if (repository.getAll().Count == 0)
            {
                throw new EntryDatabaseException();
            }


            return repository.getAll();
        }


    }
}