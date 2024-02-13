using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class Orders
    {
        private string _connectionString;
        private DataBase _db;
        public Orders() 
        {
            _connectionString = "Server= localhost; Database= ADO; Integrated Security=True;";
            _db = new DataBase(_connectionString);
        }
        public void CreateOrder(string status, int productId)
        {
            string query = $"INSERT INTO Orders VALUES ('{status}','{DateTime.Now}','{DateTime.Now}','{productId}')";
            _db.Create(query);
        }
        public List<Order> GetOrders()
        {
            string query = "SELECT * FROM Orders";
            var dataTable = _db.Read(query);
            List<Order> list = dataTable.Rows.OfType<DataRow>()
            .Select(dr => new Order()
            {
                OrderId = dr.Field<int>("OrderId"),
                OrderStatus = dr.Field<string>("OrderStatus"),
                CreatedDate = dr.Field<DateTime>("CreatedDate"),
                UpdatedDate = dr.Field<DateTime>("UpdatedDate"),
                ProductId = dr.Field<int>("ProductId")

            }).ToList();
            return list;
        }
        public void UpdateOrder(int id, string newStatus)
        {
            string query = "UPDATE Orders SET OrderStatus = '" + newStatus + "' WHERE OrderId =" + id;
            _db.Update(query);
        }
        public void DeleteOrder(int id)
        {
            string query = "DELETE FROM Orders WHERE OrderId =" + id;
            _db.Delete(query);
        }
        public List<Order> ExecuteSP(string status, DateTime date)
        {
            var dataTable = _db.ExecuteStoredProcedure(status, date);
            List<Order> list = dataTable.Rows.OfType<DataRow>()
            .Select(dr => new Order()
            {
                OrderId = dr.Field<int>("OrderId"),
                OrderStatus = dr.Field<string>("OrderStatus"),
                CreatedDate = dr.Field<DateTime>("CreatedDate"),
                UpdatedDate = dr.Field<DateTime>("UpdatedDate"),
                ProductId = dr.Field<int>("ProductId")

            }).ToList();
            return list;
        }
        public void DeleteOrders()
        {
            string query = "DELETE FROM Orders";
            _db.Delete(query);
        }
    }
}
