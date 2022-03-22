using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataAccess
{
    public class ConexionDA
    {
        public OracleConnection GetSqlConnection()
        {
            string connectionString = "Data Source=localhost;User Id=bdEmpleado;Password=bdEmpleado;";
            var connection = new OracleConnection(connectionString);
            return connection;
        }

        public OracleConnection Open()
        {
            var connection = GetSqlConnection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
                
            return connection;
        }

        public OracleConnection Close()
        {
            var connection = GetSqlConnection();
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
               
            return connection;
        }
    }
}
