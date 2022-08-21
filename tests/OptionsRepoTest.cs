using online_shop.Repositories;
using Xunit;

namespace tests
{
    public class OptionsRepoTest
    {
        private OptionRepository repo = new OptionRepository();

        public OptionsRepoTest()
        {
            repo = new OptionRepository();
        }

        [Fact]

        public void testGetAll()
        {
            Assert.Empty(repo.getAll());
        }
    }
}