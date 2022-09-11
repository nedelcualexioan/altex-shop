using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using online_shop.Models;

namespace online_shop.Repositories
{
    public class ProductRepository
    {
        private readonly string connectionString;

        private DataAcces db;

        public ProductRepository()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public ProductRepository(string text)
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString(text);
        }

        public void deleteAll()
        {
            string sql = "DELETE FROM products";

            db.SaveData(sql, new { }, connectionString);
        }

        public List<Product> getAll()
        {
            string sql = "SELECT * FROM products";

            return db.LoadData<Product, dynamic>(sql, new { }, connectionString);
        }

        public List<Product> getByCategory(int category_id)
        {
            string sql = "SELECT * FROM products WHERE category_id = @category_id";

            return db.LoadData<Product, dynamic>(sql, new { category_id }, connectionString);
        }

        public List<Product> getCategorySortBy(int category_id, string sort)
        {

            string sql = "SELECT * FROM products WHERE category_id = @category_id ORDER BY @sort";

            return db.LoadData<Product, dynamic>(sql, new { category_id, sort }, connectionString);
        }

        public Product getById(int id)
        {
            string sql = "SELECT * FROM products WHERE id = @id";

            return db.LoadData<Product, dynamic>(sql, new { id }, connectionString)[0];

        }

        public Product getByName(String name)
        {
            string sql = "SELECT * FROM products WHERE name = @name";

            return db.LoadData<Product, dynamic>(sql, new { name }, connectionString)[0];

        }

        public List<Product> getRandom(int count)
        {
            string sql = "SELECT * FROM products ORDER BY RAND() LIMIT @count";

            return db.LoadData<Product, dynamic>(sql, new { count }, connectionString);
        }

        public void deleteById(int id)
        {
            string sql = "DELETE FROM products WHERE id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void deleteByName(string name)
        {
            string sql = "DELETE FROM products WHERE name = @name";

            db.SaveData(sql, new { name }, connectionString);
        }

        public void create(Product prod)
        {
            string sql =
                "INSERT INTO products (name, price, image, folder, category_id, stock) VALUES (@name, @price, @image, @folder, @category_id, @stock)";

            db.SaveData(sql,
                new
                {
                    name = prod.Name,
                    price = prod.Price,
                    image = prod.Image,
                    folder = prod.Folder,
                    category_id = prod.CategoryId,
                    stock = prod.Stock
                }, connectionString);
        }

        public void updateNameById(int id, string name)
        {
            string sql = "UPDATE products SET name = @name WHERE id = @id";

            db.SaveData(sql, new { id, name }, connectionString);
        }

        public void updatePriceById(int id, int price)
        {
            string sql = "UPDATE products SET price = @price WHERE id = @id";

            db.SaveData(sql, new { id, price }, connectionString);
        }
    }
}