using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDeDatos;
using System.Data.SqlClient;

namespace LogicaDeNegocio
{
    public class EncargadoDeOrganizacionDAO : IEncargadoDeOrganizacionDAO
    {
        public EncargadoDeOrganizacion CargarEncargadoDeOrganizacion(int idOrganizacion)
        {
            ConexionBD conexionBD = new ConexionBD();
            EncargadoDeOrganizacion encargadoDeOrganizacion = new EncargadoDeOrganizacion();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM encargadodeOrganizacion WHERE FK_idorganizacionVinculada = @busquedaOrganizacion", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("busquedaOrganizacion", idOrganizacion));
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        encargadoDeOrganizacion.IdEncargadoDeOrganizacion = reader.GetInt32(0);
                        encargadoDeOrganizacion.Nombre = reader.GetString(1);
                        encargadoDeOrganizacion.ApellidoPaterno = reader.GetString(2);
                        encargadoDeOrganizacion.ApellidoMaterno = reader.GetString(3);
                        encargadoDeOrganizacion.Cargo = reader.GetString(4);
                        encargadoDeOrganizacion.IdOrganizacion = reader.GetInt32(5);
                    }
                }
                conexionBD.CloseConnection();
            }
            return encargadoDeOrganizacion;
        }

        public void GuardarEncargadoDeOrganizacion(EncargadoDeOrganizacion nuevoEncargadoDeOrganizacion)
        {
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO encargadodeOrganizacion VALUES (@id, @nombre, @apellidoPaterno, @apellidoMaterno, @cargo, @idOrganizacion)"))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("id", null));
                    sqlCommand.Parameters.Add(new SqlParameter("nombre", nuevoEncargadoDeOrganizacion.Nombre));
                    sqlCommand.Parameters.Add(new SqlParameter("apellidoPaterno", nuevoEncargadoDeOrganizacion.ApellidoPaterno));
                    sqlCommand.Parameters.Add(new SqlParameter("apellidoMaterno", nuevoEncargadoDeOrganizacion.ApellidoMaterno));
                    sqlCommand.Parameters.Add(new SqlParameter("cargo", nuevoEncargadoDeOrganizacion.Cargo));
                    sqlCommand.Parameters.Add(new SqlParameter("idOrganizacion", nuevoEncargadoDeOrganizacion.IdOrganizacion));

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
