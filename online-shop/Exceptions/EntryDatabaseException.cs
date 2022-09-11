using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Exceptions
{
   public  class EntryDatabaseException:Exception
    {
        public EntryDatabaseException() : base("No products in database")
        {


        }
    }
}