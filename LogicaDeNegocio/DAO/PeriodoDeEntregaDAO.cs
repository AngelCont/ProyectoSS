using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDeDatos;

namespace LogicaDeNegocio
{
    public class PeriodoDeEntregaDAO : IPeriodoDeEntregaDAO
    {
        public void EstablecerPeriodoDeEntregaDAO(PeriodoDeEntrega nuevoPeriodoDeEntrega)
        {
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO periodoEntrega VALUES(@id, @fechaInicial, @fechaFinal)", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("id", null));
                    sqlCommand.Parameters.Add(new SqlParameter("fechaInicial", nuevoPeriodoDeEntrega.FechaInicio));
                    sqlCommand.Parameters.Add(new SqlParameter("fechaFinal", nuevoPeriodoDeEntrega.FechaFin));

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
