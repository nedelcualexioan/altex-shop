using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using online_shop.Exceptions;
using online_shop.Models;
using online_shop.Repositories;
using online_shop.Services;

namespace online_shop
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"W:\Documents\SQL\online-shop\altex\bin\Debug\net5.0-windows\images\products\s22ultra";

            foreach (string s in Directory.GetDirectories(path))
            {
                Console.WriteLine(s);
            }
            


        }
    }
}
