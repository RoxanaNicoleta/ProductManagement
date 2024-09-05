using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApp
{   //gestionarea unei liste de produse (adaugare/stergere/actualizare) si implementare ununi mecanism de observare
    public class ProductList
    {
        // Lista privata de produse.

        private List<IProduct> _products = new List<IProduct>();

        // Lista privata de observatori care vor fi notificati la modificari.

        private List<IProductObserver> _observers = new List<IProductObserver>();

        // Proprietate care expune lista de produse ca o lista doar citire.
        public IReadOnlyList<IProduct> Products => _products.AsReadOnly();
        
        // Adauga un produs in lista si notifica observatorii
        public void AddProduct(IProduct product)
        {
            _products.Add(product);
            NotifyObservers();
        }

        // Sterge un produs din lista si notifica observatorii
        public void RemoveProduct(IProduct product)
        {
            _products.Remove(product);
            NotifyObservers();
        }

        // Aboneaza un observator pentru a fi notificat la schimbari
        public void Subscribe(IProductObserver observer)
        {
            _observers.Add(observer);
        }

        // Dezaboneaza un observator pentru a nu mai fi notificat
        public void Unsubscribe(IProductObserver observer)
        {
            _observers.Remove(observer);
        }

        // Actualizeaza un produs in lista sau adauga unul nou daca nu exista
        public void UpdateProduct(IProduct updatedProduct)
        {
            // Căutăm produsul existent și-l actualizăm
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Name == updatedProduct.Name)
                {
                    _products[i] = updatedProduct;
                    NotifyObservers();
                    return;
                }
            }

            // Dacă produsul nu există, adăugăm unul nou
            AddProduct(updatedProduct);
        }

        // Notifica toti observatorii despre schimbarile din lista de produse
        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_products);
            }
        }
    }
}
