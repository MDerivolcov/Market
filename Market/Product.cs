using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Market
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Product() { }
        public Product(string id, string name, double price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
