using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Exceptions;
using online_shop.Models;
using online_shop.Repositories;

namespace online_shop.Services
{
    public class CustomerServices
    {

        private CustomerRepository repository;

        public CustomerServices()
        {
            repository = new CustomerRepository();
        }
        public CustomerServices(String database)
        {
            repository = new CustomerRepository(database);
        }

        public bool isCustomer(string email)
        {
            return repository.isCustomer(email);
        }

        public void create(string fullName, string email, string phone, string password)
        {

            repository.create(new Customer(email, password, fullName, null, null, phone));

        }

        public void deleteById(int id)
        {
            if (id >= repository.getAll().Count)
                throw new EntryDatabaseException();

            repository.deleteById(id);
        }

    }
}
