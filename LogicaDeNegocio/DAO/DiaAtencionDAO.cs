using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDeDatos;
using System.Data.SqlClient;

namespace LogicaDeNegocio
{
    public class DiaAtencionDAO : IDiaAtencionDAO
    {
        public DiaAtencion CargarDiaAtencion(int idTecnico)
        {
            ConexionBD acceso = new ConexionBD();
            DiaAtencion diaAtencion = new DiaAtencion();

            using (SqlConnection sqlConnection = acceso.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM diaAtencion WHERE FK_idtecnicoAcademico = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idTecnico));

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        diaAtencion.IdDiaAtencion = reader.GetInt32(0);
                        diaAtencion.Dia = reader.GetString(1);
                        diaAtencion.HoraInicio = reader.GetInt32(2);
                        diaAtencion.HoraFin = reader.GetInt32(3);
                        diaAtencion.Lugar = reader.GetString(4);
                        diaAtencion.IdTecnicoAcademico = reader.GetInt32(5);
                    }
                }
                acceso.CloseConnection();
            }
            return diaAtencion;
        }

        public void GuardarNuevoDiaAtencion(DiaAtencion nuevoDiaAtención)
        {
            ConexionBD acceso = new ConexionBD();

            using (SqlConnection sqlConnection = acceso.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO  VALUES (@id, @dia, @horaInicio, @horaFin, @lugar, @tecnico)"))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("id", null));
                    sqlCommand.Parameters.Add(new SqlParameter("dia", nuevoDiaAtención.Dia));
                    sqlCommand.Parameters.Add(new SqlParameter("horaInicio", nuevoDiaAtención.HoraInicio));
                    sqlCommand.Parameters.Add(new SqlParameter("horaFin", nuevoDiaAtención.HoraFin));
                    sqlCommand.Parameters.Add(new SqlParameter("lugar", nuevoDiaAtención.Lugar));
                    sqlCommand.Parameters.Add(new SqlParameter("tecnico", null));

                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                acceso.CloseConnection();
            }
        }
    }
}
