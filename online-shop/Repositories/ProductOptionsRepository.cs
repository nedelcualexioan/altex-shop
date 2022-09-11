using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using online_shop.Models;

namespace online_shop.Repositories
{
    public class ProductOptionsRepository
    {
        private readonly string connectionString;

        private DataAcces db;

        public ProductOptionsRepository()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public ProductOptionsRepository(string text)
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString(text);
        }

        public List<ProductOptions> getAll()
        {
            string sql = "SELECT * FROM product_options";

            return db.LoadData<ProductOptions, dynamic>(sql, new { }, connectionString);
        }

        public ProductOptions getById(int id)
        {
            string sql = "SELECT * FROM product_options WHERE id = @id";

            return db.LoadData<ProductOptions, dynamic>(sql, new { id }, connectionString)[0];

        }

        public void deleteById(int id)
        {
            string sql = "DELETE FROM product_options WHERE id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void create(ProductOptions opt)
        {
            string sql =
                "INSERT INTO orders (option_id, product_id) VALUES (@option_id, @product_id)";

            db.SaveData(sql,
                new
                {
                    option_id = opt.OptionId,
                    product_id = opt.ProductId
                }, connectionString);
        }
    }
}