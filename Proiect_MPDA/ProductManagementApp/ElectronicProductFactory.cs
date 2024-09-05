using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApp
{
    // Clasa ElectronicProductFactory extinde clasa ProductFactory
    public class ElectronicProductFactory : ProductFactory
    {
        // Suprascrie metoda abstracta CreateProduct din ProductFactory

        public override IProduct CreateProduct(string name, decimal price)
        {
            // Creeaza si returneaza o noua instanta de ElectronicProduct cu numele si pretul specificate
            return new ElectronicProduct(name, price);
        }
    }
}
