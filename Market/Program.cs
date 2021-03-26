using System;
using System.IO;
using System.Collections.Generic;

namespace Market
{
    /// <summary>
    /// Create a console application to control stock in local market.
    ///The next requirments should be considered during implementation:
    ///
    ///1. User should be able add new item in stock
    ///2. User should be able to remove item from stock
    ///3. User should be able to view items from stock
    ///4. User should be able to search by item name
    ///5. User should be able to sort items by name, price(Any sort algorithm)
    ///6. Stock should be saved in file in any fromat(CSV easiest, XML or Json will do as well)
    ///7. Item should contains Name, Description, Id, Price
    /// </summary>
    class Program
    {
        public static void DeleteFileOut()
        {
            File.Delete("C:\\Users\\mderivolcov\\source\\repos\\market.txt");
            File.Delete("C:\\Users\\mderivolcov\\source\\repos\\market_after_delete.txt");
            File.Delete("C:\\Users\\mderivolcov\\source\\repos\\market_find.txt");
        }
        static void Main(string[] args)
        {
            DeleteFileOut();

            Market M1 = new Market();

            Product prod1 = new Product("id_00001", "candy", 15.5, "description candy");
            Product prod2 = new Product("id_00002", "milk", 11.3, "description milk");
            Product prod3 = new Product("id_00003", "bread", 3.25, "description bread");
            Product prod4 = new Product("id_00004", "bread2", 4.25, "description bread2");
            
            M1.AddProduct(prod1);
            M1.AddProduct(prod2);
            M1.AddProduct(prod3);
            M1.AddProduct(prod4);
            Console.WriteLine();

            M1.FindProducts("bread");
            M1.ViewProducts();
            M1.SortProducts();
            M1.DeleteProduct("id_00002");
        }
    }
}
