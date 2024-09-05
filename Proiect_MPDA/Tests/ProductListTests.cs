using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductManagementApp;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class ProductListTests
    {
        [TestMethod]
        public void AddProduct_Should_AddProductToList()
        //Testează dacă metoda AddProduct adaugă corect un produs în lista de produse.
        {
            // Arrange
            var productList = new ProductList();
            var product = new ElectronicProduct("Laptop", 999.99m);

            // Act
            productList.AddProduct(product);

            // Assert
            Assert.AreEqual(1, productList.Products.Count);
            Assert.AreEqual("Laptop", productList.Products[0].Name);
        }

        [TestMethod]
        public void RemoveProduct_Should_RemoveProductFromList() 
        //Testează dacă metoda RemoveProduct elimină corect un produs din lista de produse.
        {
            // Arrange
            var productList = new ProductList();
            var product = new ElectronicProduct("Phone", 499.99m);
            productList.AddProduct(product);

            // Act
            productList.RemoveProduct(product);

            // Assert
            Assert.AreEqual(0, productList.Products.Count);
        }

        [TestMethod]
        public void UpdateProduct_Should_UpdateExistingProduct() 
         //Testează dacă metoda UpdateProduct actualizează corect un produs existent în lista de produse.
        {
            // Arrange
            var productList = new ProductList();
            var product = new ElectronicProduct("Tablet", 299.99m);
            productList.AddProduct(product);

            var updatedProduct = new ElectronicProduct("Tablet", 259.99m);

            // Act
            productList.UpdateProduct(updatedProduct);

            // Assert
            Assert.AreEqual(1, productList.Products.Count);
            Assert.AreEqual(259.99m, productList.Products[0].Price);
        }

        [TestMethod]
        public void NotifyObservers_Should_CallUpdateOnAllObservers()
        //Verificarea comportamentului de notificare al observatorilor abonați folosind Moq pentru
        //a simula și verifica interacțiunile cu observatorii (IProductObserver).
        {
            // Arrange
            var productList = new ProductList();
            var mockObserver = new Mock<IProductObserver>();

            productList.Subscribe(mockObserver.Object);

            var product = new ElectronicProduct("Smartwatch", 199.99m);

            // Act
            productList.AddProduct(product);

            // Assert
            mockObserver.Verify(o => o.Update(It.IsAny<List<IProduct>>()), Times.Once);
        }
    }
}
