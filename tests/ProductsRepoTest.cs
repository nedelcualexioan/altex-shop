using System;
using System.Diagnostics;
using online_shop.Models;
using online_shop.Repositories;
using online_shop.Exceptions;
using Xunit;
using Xunit.Abstractions;

namespace tests
{
    public class ProductsRepoTest
    {
        private ProductRepository prodRepo;

        private ITestOutputHelper output;
        public ProductsRepoTest(ITestOutputHelper output)
        {
            prodRepo = new ProductRepository();
            this.output = output;

            output.WriteLine("aici");

        }

        [Fact]
        public void testGetAll()
        {
            Assert.Throws<EntryDatabaseException>(() =>
            {

                prodRepo.getAll();

            });
        }

        [Fact]
        public void testGetByName()
        {
            Assert.NotNull(prodRepo.getByName("S21"));
        }

        [Fact]

        public void testGetById()
        {
            Assert.NotNull(prodRepo.getById(1));
        }

        [Fact]

        public void deleteById()
        {
            Product prod = prodRepo.getById(1);

            prodRepo.deleteById(1);

            Assert.DoesNotContain(prod, prodRepo.getAll());
        }

        [Fact]
        public void deleteByName()
        {
            Product prod = prodRepo.getByName("S21");

            prodRepo.deleteByName("S21");

            Assert.DoesNotContain(prod, prodRepo.getAll());
        }

        [Fact]
        public void testCreate()
        {
            Product p = new Product("S21", 3500, "S21.png", 1, 150);

            prodRepo.create(p);

            Assert.Contains(p, prodRepo.getAll());
        }

        [Fact]

        public void testUpdateNameById()
        {
            Product prod = prodRepo.getByName("S21");

            prodRepo.updateNameById(prod.Id, "test");

            Assert.DoesNotContain(prod, prodRepo.getAll());

        }
    }
}