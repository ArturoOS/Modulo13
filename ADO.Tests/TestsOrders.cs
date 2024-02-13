using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ADO.Tests
{
    [TestClass]
    public class TestsOrders
    {
        [TestMethod]
        public void CreateOrder()
        {
            Random rand = new Random();
            string productName = "Product" + rand.Next(1, 1001).ToString();

            Products db = new Products();
            db.CreateProduct("100", productName, "100", "productDescription", "100");
            var product = db.GetProducts().Where(x => x.ProductName == productName).FirstOrDefault();

            Orders dbOrders = new Orders();
            dbOrders.CreateOrder("NotStarted",product.ProductId);

            var orders = dbOrders.GetOrders().Where(x => x.ProductId == product.ProductId);
            Assert.IsTrue(orders.Count() == 1);
        }
        [TestMethod]
        public void UpdateOrder()
        {
            Random rand = new Random();
            string productName = "Product" + rand.Next(1, 1001).ToString();

            Products db = new Products();
            db.CreateProduct("100", productName, "100", "productDescription", "100");
            var product = db.GetProducts().Where(x => x.ProductName == productName).FirstOrDefault();

            Orders dbOrders = new Orders();
            dbOrders.CreateOrder("NotStarted", product.ProductId);
            var order = dbOrders.GetOrders().Where(x => x.ProductId == product.ProductId).FirstOrDefault();
            dbOrders.UpdateOrder(order.OrderId, "Loading");

            var orders = dbOrders.GetOrders().Where(x => x.ProductId == product.ProductId && x.OrderStatus == "Loading");
            Assert.IsTrue(orders.Count() == 1);
        }
        [TestMethod]
        public void GetOrderBy()
        {
            Random rand = new Random();
            string productName = "Product" + rand.Next(1, 1001).ToString();

            Products db = new Products();
            db.CreateProduct("100", productName, "100", "productDescription", "100");
            var product = db.GetProducts().Where(x => x.ProductName == productName).FirstOrDefault();

            Orders dbOrders = new Orders();
            dbOrders.CreateOrder("Arrived", product.ProductId);

            var orders = dbOrders.ExecuteSP("Arrived",DateTime.Now);
            Assert.IsTrue(orders.Count() == 1);
        }
        [TestMethod]
        public void DeleteOrder()
        {
            Random rand = new Random();
            string productName = "Product" + rand.Next(1, 1001).ToString();

            Products db = new Products();
            db.CreateProduct("100", productName, "100", "productDescription", "100");
            var product = db.GetProducts().Where(x => x.ProductName == productName).FirstOrDefault();

            Orders dbOrders = new Orders();
            dbOrders.CreateOrder("NotStarted", product.ProductId);
            var order = dbOrders.GetOrders().Where(x => x.ProductId == product.ProductId).FirstOrDefault();
            dbOrders.DeleteOrder(order.OrderId);

            var orders = dbOrders.GetOrders().Where(x => x.ProductId == product.ProductId);
            Assert.IsTrue(orders.Count() == 0);
        }
        [TestMethod]
        public void DeleteOrders()
        {
            Orders db = new Orders();
            db.DeleteOrders();

            var orders = db.GetOrders();
            Assert.IsTrue(orders.Count() == 0);
        }
    }
}
