using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDeDatos;
using System.Data.SqlClient;

namespace LogicaDeNegocio
{
    public class SolicitudDAO : ISolicitudDAO
    {
        public List<Solicitud> CargarSolicitudes()
        {
            List<Solicitud> solicitudes = new List<Solicitud>();
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Solicitud", sqlConnection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Solicitud solicitud = new Solicitud();

                        solicitud.IdProyecto = reader.GetInt32(0);
                        solicitud.IdAlumno = reader.GetInt32(1);
                    }
                }
                conexionBD.CloseConnection();
            }
            return solicitudes;
        }

        public void GuardarSolicitud(Solicitud nuevaSolicitud)
        {
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Solicitud VALUES(@proyecto, @alumno)", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("proyecto", nuevaSolicitud.IdProyecto));
                    sqlCommand.Parameters.Add(new SqlParameter("alumno", nuevaSolicitud.IdAlumno));

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
