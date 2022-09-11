using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using online_shop.Models;

namespace online_shop.Repositories
{
    public class OptionRepository
    {
        private readonly string connectionString;

        private DataAcces db;

        public OptionRepository()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public OptionRepository(string text)
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"W:\Documents\SQL\online-shop\online-shop\bin\Debug\net5.0")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString(text);
        }

        public List<Option> getAll()
        {
            string sql = "SELECT * FROM options";

            return db.LoadData<Option, dynamic>(sql, new { }, connectionString);
        }

        public Option getById(int id)
        {
            string sql = "SELECT * FROM options WHERE id = @id";

            return db.LoadData<Option, dynamic>(sql, new { id }, connectionString)[0];

        }

        public Option getByName(String name)
        {
            string sql = "SELECT * FROM options WHERE option_name = @option_name";

            return db.LoadData<Option, dynamic>(sql, new { option_name = name }, connectionString)[0];

        }

        public void deleteById(int id)
        {
            string sql = "DELETE FROM options WHERE id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void deleteByName(string name)
        {
            string sql = "DELETE FROM options WHERE option_name = @option_name";

            db.SaveData(sql, new { option_name = name }, connectionString);
        }

        public void create(Option opt)
        {
            string sql =
                "INSERT INTO options (option_name) VALUES (@option_name)";

            db.SaveData(sql, new { option_name = opt.OptionName }, connectionString);
        }

        public void updateNameById(int id, string name)
        {
            string sql = "UPDATE options SET option_name = @option_name WHERE id = @id";

            db.SaveData(sql, new { id, option_name = name }, connectionString);
        }
    }
}