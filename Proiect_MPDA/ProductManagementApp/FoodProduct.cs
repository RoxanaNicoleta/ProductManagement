using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApp
{
    // Clasa FoodProduct implementeaza interfata IProduct

    public class FoodProduct: IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public FoodProduct(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
