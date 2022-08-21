using online_shop.Repositories;
using Xunit;

namespace tests
{
    public class OrdersRepoTest
    {
        private OrderRepository repo;

        public OrdersRepoTest()
        {
            repo = new OrderRepository();
        }

        [Fact]

        public void testGetAll()
        {
            Assert.Empty(repo.getAll());
        }
    }
}