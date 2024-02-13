using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class DataBase
    {
        private string _connectionString;
        private SqlConnection _connection;
        public DataBase(string connectionString) 
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }
        public bool Create(string insertQuery) 
        {
            try
            {
                SqlCommand cmd = new SqlCommand(insertQuery, _connection);
                _connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                throw new Exception("ERROR SQL: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: " + e.Message);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public DataTable Read(string readQuery) 
        {
            try
            {
                SqlCommand cmd = new SqlCommand(readQuery, _connection);
                _connection.Open();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (SqlException e)
            {
                throw new Exception("ERROR SQL: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: " + e.Message);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public bool Update(string updateQuery)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(updateQuery, _connection);
                _connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                throw new Exception("ERROR SQL: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: " + e.Message);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public bool Delete(string deleteQuery) 
        {
            try
            {
                SqlCommand cmd = new SqlCommand(deleteQuery, _connection);
                _connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                throw new Exception("ERROR SQL: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: " + e.Message);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public DataTable ExecuteStoredProcedure(string status, DateTime date) 
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetOrders", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@OrderStatus", status));
                cmd.Parameters.Add(new SqlParameter("@Date", date));
                _connection.Open();

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException e)
            {
                throw new Exception("ERROR SQL: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: " + e.Message);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
    }
}
