using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ADO.Tests
{
    [TestClass]
    public class TestsProducts
    {
        [TestMethod]
        public void CreateProduct()
        {
            Random rand = new Random();
            string productName = "Product" + rand.Next(1, 1001).ToString();

            Products db = new Products();
            db.CreateProduct("100",productName,"100","productDescription","100");

            var products = db.GetProducts().Where(x => x.ProductName == productName);
            Assert.IsTrue(products.Count() == 1);
        }
        [TestMethod]
        public void UpdateProduct()
        {
            Random rand = new Random();
            string productName = "Product" + rand.Next(1, 1001).ToString();
            string newProductName = "Product" + rand.Next(1, 1001).ToString();

            Products db = new Products();
            db.CreateProduct("100", productName, "100", "productDescription", "100");
            var product = db.GetProducts().Where(x => x.ProductName == productName).FirstOrDefault();
            db.UpdateProduct(product.ProductId,"100", newProductName, "100", "productDescription", "100");

            var products = db.GetProducts().Where(x => x.ProductName == newProductName);
            Assert.IsTrue(products.Count() == 1);
        }
        [TestMethod]
        public void DeleteProduct()
        {
            Random rand = new Random();
            string productName = "Product" + rand.Next(1001, 2001).ToString();

            Products db = new Products();
            db.CreateProduct("100", productName, "100", "productDescription", "100");
            var product = db.GetProducts().Where(x => x.ProductName == productName).FirstOrDefault();
            db.DeleteProduct(product.ProductId);

            var products = db.GetProducts().Where(x => x.ProductName == productName);
            Assert.IsTrue(products.Count() == 0);
        }
        [TestMethod]
        public void DeleteProducts()
        {
            Products db = new Products();
            db.DeleteProducts();
            var products = db.GetProducts();
            Assert.IsTrue(products.Count() == 0);
        }
    }
}
