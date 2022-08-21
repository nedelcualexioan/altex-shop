using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using online_shop.Models;

namespace online_shop.Repositories
{
    public class OrderRepository
    {
        private readonly string connectionString;

        private DataAcces db;

        public OrderRepository()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"W:\Documents\SQL\online-shop\online-shop\bin\Debug\net5.0")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Order> getAll()
        {
            string sql = "SELECT * FROM orders";

            return db.LoadData<Order, dynamic>(sql, new { }, connectionString);
        }

        public Order getById(int id)
        {
            string sql = "SELECT * FROM orders WHERE id = @id";

            return db.LoadData<Order, dynamic>(sql, new { id }, connectionString)[0];

        }

        public void deleteById(int id)
        {
            string sql = "DELETE FROM orders WHERE id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }
        public void create(Order ord)
        {
            string sql =
                "INSERT INTO orders (customer_id, amount, shipping_address, order_date, order_status) VALUES (@customer_id, @amount, @shipping_address, @order_date, @order_status)";

            db.SaveData(sql,
                new
                {
                    customer_id = ord.CustomerId,
                    amount = ord.Ammount,
                    shipping_address = ord.ShippingAddress,
                    order_date = ord.OrderDate,
                    order_status = ord.OrderStatus
                }, connectionString);
        }

        public void updateAmountById(int id, int amount)
        {
            string sql = "UPDATE orders SET amount = @amount WHERE id = @id";

            db.SaveData(sql, new { id, amount }, connectionString);
        }
    }
}