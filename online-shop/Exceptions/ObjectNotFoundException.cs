using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Exceptions
{
    public class ObjectNotFoundException : Exception
    {

        public ObjectNotFoundException() : base("Object not found in the database")
        {

        }

    }
}
