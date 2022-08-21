using online_shop.Models;
using online_shop.Repositories;
using Xunit;

namespace tests
{
    public class ProductsRepoTest
    {
        private ProductRepository prodRepo;

        public ProductsRepoTest()
        {
            prodRepo = new ProductRepository();
        }

        [Fact]
        public void testGetAll()
        {
            Assert.NotEmpty(prodRepo.getAll());
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