using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class Products
    {
        private string _connectionString;
        private DataBase _db;
        public Products()
        {
            _connectionString = "Server=localhost;Database=mydatabase;User=myuser;Password=mypassword;";
            _db = new DataBase(_connectionString);
        }
        public void CreateProduct(string values)
        {
            string query = "INSERT INTO Products VALUES (" + values + ")";
            _db.Create(query);
        }
        public DataTable GetProducts()
        {
            string query = "SELECT * FROM Products";
            return _db.Read(query);
        }
        public void UpdateProduct(int id, string values)
        {
            string query = "UPDATE Products SET VALUES = '" + values + "' WHERE id =" + id;
            _db.Update(query);
        }
        public void DeleteProduct(int id)
        {
            string query = "DELETE FROM Products WHERE id =" + id;
            _db.Delete(query);
        }
        public void ExecuteSP(string spName, Dictionary<string, object> parameters) 
        {
            _db.ExecuteStoredProcedure(spName, parameters);
        }
    }
}
