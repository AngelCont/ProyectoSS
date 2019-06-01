using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDeDatos;
using System.Data.SqlClient;

namespace LogicaDeNegocio
{
    public class CoordinadorTienePeriodoEntregaDAO : ICoordinadorTienePeriodoEntregaDAO
    {
        public void AsignarCoordinadorPeriodo(int idCoordinador, int idPeriodo)
        {
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO coordinador_tiene_periodoEntrega VALUES(@coordinador, @periodo)", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("coordinador", idCoordinador));
                    sqlCommand.Parameters.Add(new SqlParameter("periodo", idPeriodo));

                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                conexionBD.CloseConnection();
            }
        }
    }
}
