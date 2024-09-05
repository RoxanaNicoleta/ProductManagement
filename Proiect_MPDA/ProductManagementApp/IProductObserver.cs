using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApp
{
    // Defineste interfata IProductObserver care urmeaza modelul Observer
    public interface IProductObserver
    {
        // Metoda Update care va fi apelata pentru a notifica observatorul despre schimbarile din lista de produse
        void Update(List<IProduct> products);
    }
}
