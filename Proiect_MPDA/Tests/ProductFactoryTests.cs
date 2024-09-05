using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagementApp;
using System;

namespace Tests
{   //Aceste teste validează funcționalitatea factory-urilor și confirmă că produsele create respectă specificațiile date.
    [TestClass]
    public class ProductFactoryTests
    {
        [TestMethod]
        public void ElectronicProductFactory_Creates_ElectronicProduct() 
         //Testează dacă ElectronicProductFactory creează corect un obiect de tip ElectronicProduct.
        {
            // Arrange
            var factory = new ElectronicProductFactory();
            string expectedName = "Laptop";
            decimal expectedPrice = 999.99m;

            // Act
            var product = factory.CreateProduct(expectedName, expectedPrice) as ElectronicProduct;

            // Assert
            Assert.IsNotNull(product, "The product should not be null.");
            Assert.AreEqual(expectedName, product.Name, "The product name is incorrect.");
            Assert.AreEqual(expectedPrice, product.Price, "The product price is incorrect.");
        }

        [TestMethod]
        public void FoodProductFactory_Creates_FoodProduct() 
         //testează dacă FoodProductFactory creează corect un obiect de tip FoodProduct.
        {
            // Arrange
            var factory = new FoodProductFactory();
            string expectedName = "Apple";
            decimal expectedPrice = 0.99m;

            // Act
            var product = factory.CreateProduct(expectedName, expectedPrice) as FoodProduct;

            // Assert
            Assert.IsNotNull(product, "The product should not be null.");
            Assert.AreEqual(expectedName, product.Name, "The product name is incorrect.");
            Assert.AreEqual(expectedPrice, product.Price, "The product price is incorrect.");
        }
    }
}
