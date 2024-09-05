using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApp
{    // Defineste interfata IProduct care va fi implementata de diferite tipuri de produse
    public interface IProduct
    {      
        // Proprietatea 'Name' (doar citire) pentru a obtine numele produsului
        string Name { get; }
        // Proprietatea 'Price' (citire si scriere) pentru a obtine sau seta pretul produsului
        decimal Price { get; set; }
    }
}
