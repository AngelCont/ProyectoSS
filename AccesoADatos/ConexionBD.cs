using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccesoDeDatos
{
    static class Constantes
    {
        public static string connectionString = @"Data Source=Maruri-PC;Initial Catalog=ServicioSocial;User ID=adminSS;Password=***********";
    }

    public class ConexionBD
    {
        private SqlConnection sqlConnection;
        private String conexionString;
        public ConexionBD()
        {
            sqlConnection = new SqlConnection(conexionString);
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

        public void CloseConnection()
        {
            if (sqlConnection != null)
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
