using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shop.Exceptions
{
    public class NotEnoughObjectsException : Exception
    {

        public NotEnoughObjectsException() : base("Not enough objects in the database")
        {

        }

    }
}
