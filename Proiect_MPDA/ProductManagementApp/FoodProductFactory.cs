using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApp
{
    // Clasa FoodProductFactory extinde clasa abstracta ProductFactory
    public class FoodProductFactory: ProductFactory
    {        
        // Suprascrie metoda abstracta CreateProduct din ProductFactory
        public override IProduct CreateProduct(string name, decimal price)
        {
            // Creeaza si returneaza o noua instanta de FoodProduct cu numele si pretul specificate
            return new FoodProduct(name, price);
        }
    }
}
