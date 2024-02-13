using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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
            _connectionString = "Data Source=localhost;Initial Catalog=ADO;Persist Security Info=True;Integrated Security=true;";
            _db = new DataBase(_connectionString);
        }
        public void CreateProduct(string length, string name, string width, string description,string weight)
        {
            string query = $"INSERT INTO Products VALUES ('{name}','{description}','{weight}','{width}','{length}')";
            _db.Create(query);
        }
        public List<Product> GetProducts()
        {
            string query = "SELECT * FROM Products";
            var dataTable = _db.Read(query);
            List<Product> list = dataTable.Rows.OfType<DataRow>()
            .Select(dr => new Product()
            {
                ProductId = dr.Field<int>("ProductId"),
                ProductName = dr.Field<string>("ProductName"),
                ProductDescription = dr.Field<string>("ProductDescription"),
                ProductWeight = dr.Field<string>("ProductWeight"),
                ProductWidth = dr.Field<string>("ProductWidth"),
                ProductLenght = dr.Field<string>("ProductLenght")
            }).ToList();
            
            return list;
        }
        public void UpdateProduct(int id, string length, string name, string width, string description, string weight)
        {
            string query = $"UPDATE Products SET ProductName = '{name}',ProductDescription={description}, ProductWeight={weight}" +
                $" WHERE ProductId =" + id;
            _db.Update(query);
        }
        public void DeleteProduct(int id)
        {
            string query = "DELETE FROM Products WHERE ProductId =" + id;
            _db.Delete(query);
        }
        public void DeleteProducts()
        {
            string query = "DELETE FROM Products";
            _db.Delete(query);
        }
    }
}
