using online_shop.Repositories;
using Xunit;

namespace tests
{
    public class OrderDetRepoTest
    {
        private OrderDetailsRepository repo;

        public OrderDetRepoTest()
        {
            repo = new OrderDetailsRepository();
        }

        [Fact]

        public void testGetAll()
        {
            Assert.Empty(repo.getAll());
        }
    }
}