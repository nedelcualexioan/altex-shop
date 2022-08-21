using System;
using System.Collections.Generic;
using online_shop.Models;
using online_shop.Repositories;

namespace online_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryRepository repo = new CategoryRepository();

            List<Category> list = repo.getAll();

            Console.WriteLine(list[0].ToString());
        }
    }
}
