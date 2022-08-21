using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Models;
using online_shop.Repositories;

namespace online_shop.Services
{
    class CustomerServices
    {

        private CustomerRepository repository;

        public CustomerServices()
        {
            repository = new CustomerRepository();
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
                return;

            repository.deleteById(id);
        }




    }
}
