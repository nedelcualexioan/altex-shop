using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using online_shop.Models;

namespace online_shop.Repositories
{
    public class OrderDetailsRepository
    {
        private readonly string connectionString;

        private DataAcces db;

        public OrderDetailsRepository()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public OrderDetailsRepository(string text)
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"W:\Documents\SQL\online-shop\online-shop\bin\Debug\net5.0")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString(text);
        }

        public List<OrderDetails> getAll()
        {
            string sql = "SELECT * FROM order_details";

            return db.LoadData<OrderDetails, dynamic>(sql, new { }, connectionString);
        }

        public OrderDetails getById(int id)
        {
            string sql = "SELECT * FROM order_details WHERE id = @id";

            return db.LoadData<OrderDetails, dynamic>(sql, new { id }, connectionString)[0];

        }

        public void deleteById(int id)
        {
            string sql = "DELETE FROM order_details WHERE id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void create(OrderDetails det)
        {
            string sql =
                "INSERT INTO order_details (order_id, product_id, price, quantity) VALUES (@order_id, @product_id, @price, @quantity)";

            db.SaveData(sql,
                new
                {
                    order_id = det.OrderId,
                    product_id = det.ProductId,
                    price = det.Price,
                    quantity = det.Quantity
                }, connectionString);
        }

        public void updatePriceById(int id, int price)
        {
            string sql = "UPDATE order_details SET price = @price WHERE id = @id";

            db.SaveData(sql, new { id, price }, connectionString);
        }
    }
}