using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    interface IMarket
    {
        void AddProduct(Product p);
        void DeleteProduct(string id);
        void SortProducts();
        void ViewProducts();
        void FindProducts(string filter);
    }
}
