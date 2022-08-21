using System;
using online_shop.Models;
using online_shop.Repositories;
using Org.BouncyCastle.Asn1.BC;
using Xunit;

namespace tests
{
    public class CustRepoTest
    {

        private CustomerRepository customerRepo;

        public CustRepoTest()
        {
            customerRepo = new CustomerRepository();
        }

        [Fact]
        public void testGetAll()
        {
            Assert.Equal(40, customerRepo.getAll().Count);
        }

        [Fact]
        public void testGetByName()
        {
            Assert.NotNull(customerRepo.getByName("Minda Dragge"));
        }

        [Fact]

        public void testGetById()
        {
            Assert.NotNull(customerRepo.getById(1));
        }

        [Fact]

        public void deleteById()
        {
            Customer cust = customerRepo.getById(41);

            customerRepo.deleteById(41);

            Assert.DoesNotContain(cust, customerRepo.getAll());
        }

        [Fact]
        public void deleteByName()
        {
            Customer cust = customerRepo.getByName("Dodie Kuban");

            customerRepo.deleteByName("Dodie Kuban");

            Assert.DoesNotContain(cust, customerRepo.getAll());
        }

        [Fact]

        public void testIsCustomer()
        {
            Assert.False(customerRepo.isCustomer("Cosmin"));
        }

        [Fact]
        public void testCreate()
        {
            Customer cust = new Customer("gmeyshamb@berkeley.edu", "8YNOtwVwYQI", "Gabbi Meysham", "6855 Elka Road",
                "Israel", "612-153-2780");

            customerRepo.create(cust);

            Assert.Contains(cust, customerRepo.getAll());
        }

        [Fact]

        public void testUpdateNameById()
        {
            Customer cust = customerRepo.getByName("Gabbi Meysham");

            customerRepo.updateNameById(cust.Id, "test");

            Assert.DoesNotContain(cust, customerRepo.getAll());

        }
    }
}
