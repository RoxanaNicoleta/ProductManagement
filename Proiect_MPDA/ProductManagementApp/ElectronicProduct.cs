using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductManagementApp
{
    // Clasa ElectronicProduct implementeaza interfata IProduct
    public class ElectronicProduct: IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ElectronicProduct(string name, decimal price) 
        { 
            Name = name;
            Price = price;
        }
    }
}
