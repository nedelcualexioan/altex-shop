using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.CompilerServices;
using online_shop.Models;

namespace online_shop.Repositories
{
    public class CustomerRepository
    {
        private readonly string connectionString;

        private DataAcces db;

        public CustomerRepository()
        {
            db = new DataAcces();

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"W:\Documents\SQL\online-shop\online-shop\bin\Debug\net5.0")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            this.connectionString = config.GetConnectionString("Default");
        }

        public List<Customer> getAll()
        {
            string sql = "SELECT * FROM customers";

            return db.LoadData<Customer, dynamic>(sql, new { }, connectionString);
        }

        public Customer getById(int id)
        {
            string sql = "SELECT * FROM customers WHERE id = @id";

            return db.LoadData<Customer, dynamic>(sql, new { id }, connectionString)[0];

        }

        public Customer getByName(String full_name)
        {
            string sql = "SELECT * FROM customers WHERE full_name = @full_name";

            return db.LoadData<Customer, dynamic>(sql, new { full_name }, connectionString)[0];

        }

        public void deleteById(int id)
        {
            string sql = "DELETE FROM customers WHERE id = @id";

            db.SaveData(sql, new { id }, connectionString);
        }

        public void deleteByName(string fullName)
        {
            string sql = "DELETE FROM customers WHERE full_name = @full_name";

            db.SaveData(sql, new { full_name = fullName }, connectionString);
        }

        public bool isCustomer(string email)
        {
            string sql = "SELECT * FROM customers WHERE email = @email";

            return db.LoadData<Customer, dynamic>(sql, new { email }, connectionString).Count != 0;
        }

        public void create(Customer cust)
        {
            string sql =
                "INSERT INTO customers (email, password, full_name, shipping_address, country, phone) VALUES (@email, @password, @full_name, @shipping_address, @country, @phone)";

            db.SaveData(sql,
                new
                {
                    email = cust.Email, password = cust.Password, full_name = cust.FullName,
                    shipping_address = cust.ShippingAddress, country = cust.Country, phone = cust.Phone
                }, connectionString);
        }

        public void updateNameById(int id, string fullName)
        {
            string sql = "UPDATE customers SET full_name = @full_name WHERE id = @id";

            db.SaveData(sql, new { id, full_name = fullName }, connectionString);
        }

        public void updatePasswordById(int id, string password)
        {
            string sql = "UPDATE customers SET password = @password WHERE id = @id";

            db.SaveData(sql, new { id, password }, connectionString);
        }
    }
}