using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDeDatos;

namespace LogicaDeNegocio
{
    public class ExpedienteTieneCoordinadorDAO : IExpedienteTieneCoordinadorDAO
    {
        public void AsignarExpedienteCoordinador(int idExpediente, int idCoordinador)
        {
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Expediente_tiene_Coordinador VALUES(@expediente, @coordinador)", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("expediente", idExpediente));
                    sqlCommand.Parameters.Add(new SqlParameter("coordinador", idCoordinador));

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
