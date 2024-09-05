using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApp
{
    // Clasa abstracta ProductFactory defineste o interfata pentru crearea produselor
    public abstract class ProductFactory
    {
        // Metoda abstracta CreateProduct care trebuie implementata de clasele derivate
        // Aceasta metoda este responsabila de crearea unui produs specific (IProduct) cu un nume si un pret dat
        public abstract IProduct CreateProduct(string name, decimal price);
    }
}
