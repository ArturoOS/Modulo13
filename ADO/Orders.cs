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
            _connectionString = "Server=localhost;Database=mydatabase;User=myuser;Password=mypassword;";
            _db = new DataBase(_connectionString);
        }
        public void CreateOrder(string status)
        {
            string query = "INSERT INTO Orders VALUES (" + status + ")";
            _db.Create(query);
        }
        public DataTable GetOrders()
        {
            string query = "SELECT * FROM Orders";
            return _db.Read(query);
        }
        public void UpdateOrder(int id, string newStatus)
        {
            string query = "UPDATE Orders SET status = '" + newStatus + "' WHERE id =" + id;
            _db.Update(query);
        }
        public void DeleteOrder(int id)
        {
            string query = "DELETE FROM Orders WHERE id =" + id;
            _db.Delete(query);
        }
        public void ExecuteSP(string spName, Dictionary<string, object> parameters)
        {
            _db.ExecuteStoredProcedure(spName, parameters);
        }
    }
}
