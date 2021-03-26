using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Market
{
    public class Market : IMarket
    {
        const string PATH = @"C:\Users\mderivolcov\source\repos\market.txt";
        public void AddProduct(Product p)
        {
             using (StreamWriter sw = new StreamWriter(PATH, true, System.Text.Encoding.Default))
             {
                 sw.WriteLine(p.Id + ";" + p.Name + ";" + p.Price + ";" + p.Description);
             }
             Console.WriteLine("Insert succes!");
        }
        public void DeleteProduct(string id)
        {
            //All products are written to the output file, except for the one to be removed.
            var lines = File.ReadAllLines(PATH);
            var sorted = new HashSet<string>(lines.Where(x => !x.Contains(id))).ToArray();
            File.WriteAllLines("C:\\Users\\mderivolcov\\source\\repos\\market_after_delete.txt", sorted);
        }
        public void FindProducts(string filter)
        {
            //Lines matching the condition are written to a new file.
            var lines = File.ReadAllLines(PATH);
            var sorted = new HashSet<string>(lines.Where(x => x.Contains(filter))).ToArray();
            File.WriteAllLines("C:\\Users\\mderivolcov\\source\\repos\\market_find.txt", sorted);

            //Another example of the algorithm implementation
            //foreach (var p in CovertFileInObject.ConvertFileInObject(PATH))
            //{
            //    if (p.Name.Contains(filter) || p.Name.Contains(filter)) { //WRITE FILEOUT }
            //}
        }
        public void SortProducts()
        {
            var arr = CovertFileInObject.ConvertFileInObject(PATH).ToArray();
            var temp = arr[1];
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i].Price > arr[i + 1].Price)
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted by price:");
            foreach (var p in arr)
            {
                Console.WriteLine(p.Id + ";" + p.Name + ";" + p.Price + ";" + p.Description);
            }
        }
        public void ViewProducts()
        {
            Console.WriteLine("View products in market:");
            foreach (Product p in CovertFileInObject.ConvertFileInObject(PATH))
            {
                Console.WriteLine(p.Id + ";" + p.Name + ";" + p.Price + ";" + p.Description);
            }
        }
        class CovertFileInObject
        {
            public static List<Product> ConvertFileInObject(string path)
            {
                List<string> valuesList = new List<string> { };
                string row = "";
                string temp = "";
                StreamReader sr = new StreamReader(PATH);
                while (sr.EndOfStream == false)
                {
                    row = sr.ReadLine();
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (row[i] == ';')
                        {
                            valuesList.Add(temp);
                            temp = "";
                        }
                        else
                        {
                            temp += row[i].ToString();
                            if (i == row.Length - 1)
                            {
                                valuesList.Add(temp);
                                temp = "";
                            }
                        }
                    }
                }
                //Reading the entire file and saving the fields to a list. 
                //The fixed value is 4 because there are 4 fields defined for the element.
                //(the algorithm needs to be improved if new product fields are added.)

                List<Product> listProd = new List<Product> { };
                for (int i = 0; i < valuesList.Count; i += 4)
                {
                    listProd.Add(new Product(valuesList[i], valuesList[i + 1], Convert.ToDouble(valuesList[i + 2]), valuesList[i + 3]));
                }
                return listProd;
            }
        }
    }
}
