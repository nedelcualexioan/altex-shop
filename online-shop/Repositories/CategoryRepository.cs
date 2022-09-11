using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using online_shop.Models;

namespace online_shop.Repositories
{
    public class CategoryRepository
    {
        private readonly string connectionString;

        private DataAcces db;

        public CategoryRepository()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public CategoryRepository(string text)
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"W:\Documents\SQL\online-shop\online-shop\bin\Debug\net5.0")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString(text);
        }

        public List<Category> getAll()
        {
            string sql = "SELECT * FROM categories ORDER BY id";

            return db.LoadData<Category, dynamic>(sql, new { }, connectionString);
        }

        public Category getById(int id)
        {
            string sql = "SELECT * FROM categories WHERE id = @id";

            return db.LoadData<Category, dynamic>(sql, new { id }, connectionString)[0];

        }

        public Category getByName(String name)
        {
            string sql = "SELECT * FROM categories WHERE name = @name";

            return db.LoadData<Category, dynamic>(sql, new { name }, connectionString)[0];

        }

        public void deleteById(int id)
        {
            string sql = "DELETE FROM categories WHERE id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void deleteByName(string name)
        {
            string sql = "DELETE FROM categories WHERE name = @name";

            db.SaveData(sql, new { name }, connectionString);
        }

        public void create(Category cust)
        {
            string sql =
                "INSERT INTO categories (name) VALUES (@name)";

            db.SaveData(sql, new { name = cust.Name }, connectionString);
        }

        public void updateNameById(int id, string name)
        {
            string sql = "UPDATE categories SET name = @name WHERE id = @id";

            db.SaveData(sql, new { id, name }, connectionString);
        }
    }
}