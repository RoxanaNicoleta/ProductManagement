using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;


namespace ProductManagementApp
{
    public partial class MainForm : Form, IProductObserver
    {
        private ProductList _productList; // Lista de produse gestionata de MainForm
        private ProductFactory _currentFactory; // Factory-ul curent pentru crearea produselor
        public MainForm()
        {
            InitializeComponent();  // Initializeaza componentele formularului
            _productList = new ProductList();   // Creeaza o noua instanta de ProductList
            _productList.Subscribe(this);    // Aboneaza MainForm ca observator al ProductList
        }

        // Handler pentru butonul de adaugare a produselor electronice
        private void btnAddElectornic_Click(object sender, EventArgs e)
        {  // Seteaza factory-ul curent pentru produse electronice si adauga produsul folosind factory-ul curent 
            _currentFactory = new ElectronicProductFactory();
            AddProduct();
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {   // Seteaza factory-ul curent pentru produse alimentare si adauga produsul folosind factory-ul curent 
            _currentFactory = new FoodProductFactory();
            AddProduct();
        }

        private void AddProduct()
        {
            // Obținem valorile din campuri
            string name = txtName.Text.Trim();
            string priceText = txtPrice.Text.Trim();

            // Verificam daca numele sau pretul sunt goale
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(priceText))
            {
                // Afisam un MessageBox daca unul dintre campuri este gol
                MessageBox.Show("Please enter both name and price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificam daca pretul este un numar valid
            if (!decimal.TryParse(priceText, out decimal price))
            {
                // Afisam un MessageBox daca pretul nu este valid
                MessageBox.Show("Please enter a valid price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cream produsul daca toate validarile sunt corecte
            var product = _currentFactory.CreateProduct(name, price);

            // Verificam daca produsul exista deja în lista
            if (_productList.Products.Any(p => p.Name == product.Name))
            {
                // Actualizam produsul existent
                _productList.UpdateProduct(product);
            }
            else
            {
                // Adaugam produsul nou
                _productList.AddProduct(product);
            }
        }

        // Implementarea metodei Update din interfata IProductObserver
        public void Update(List<IProduct> products)
        { 
            lstProducts.Items.Clear(); // Curata lista de produse din ListBox
            foreach (var product in products)
            {
                // Adauga fiecare produs in ListBox cu formatul "Nume - Pret"
                lstProducts.Items.Add($"{product.Name} - {product.Price:C}");
            }
        }

        // Handler pentru butonul de eliminare a produselor
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Verificam daca un element este selectat in ListBox
            if (lstProducts.SelectedItem != null)
            {
                // Obtinem textul elementului selectat
                string selectedItemText = lstProducts.SelectedItem.ToString();

                // Cautam produsul in lista de produse
                var productToRemove = _productList.Products.FirstOrDefault(p => $"{p.Name} - {p.Price:C}" == selectedItemText);

                if (productToRemove != null)
                {
                    // Eliminam produsul din lista de produse
                    _productList.RemoveProduct(productToRemove);
                }
            }
            else
            {
                // Afisam un MessageBox daca niciun element nu este selectat
                MessageBox.Show("Please select a product to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
