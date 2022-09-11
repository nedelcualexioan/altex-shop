using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_shop.Exceptions;
using online_shop.Services;
using Xunit;

namespace tests
{
    public class ProductServicesTest
    {
        private ProductsServices services;

        public ProductServicesTest()
        {
            services = new ProductsServices("Test");

            Debug.WriteLine("aici");
        }


        [Fact]

        public void testGetAll()
        {
            Assert.Throws<EntryDatabaseException>(() => services.getAllProducts());
        }

    }
}
