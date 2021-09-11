using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace Day35Classwork
{
    public class LinqToDataTableDemo
    {
        public void AddToDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("ProductName");

            table.Rows.Add("1", "Chai");
            table.Rows.Add("2", "Queso Cabrales");
            table.Rows.Add("3", "Tofu");

            DisplayProductsFromTable(table);
        }

        public void DisplayProductsFromTable(DataTable table)
        {
            var productNames = from products in table.AsEnumerable() select products.Field<String>("ProductName");
            Console.WriteLine("Product Names: ");
            foreach(string productName in productNames)
            {
                Console.WriteLine(productName);
            }
        }
    }
}
