using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDeDatos;
using System.Data.SqlClient;

namespace LogicaDeNegocio
{
    public class OrganizacionVinculadaDAO : IOrganizacionVinculadaDAO
    {
        public List<OrganizacionVinculada> CargarListaOrganizacionVinculada()
        {
            ConexionBD conexionBD = new ConexionBD();
            List<OrganizacionVinculada> organizacionesVinculadas = new List<OrganizacionVinculada>();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM organizacionVinculada", sqlConnection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        OrganizacionVinculada organizacionVinculada = new OrganizacionVinculada();

                        organizacionVinculada.IdOrganizacionVinculada = reader.GetInt32(0);
                        organizacionVinculada.Ciudad = reader.GetString(1);
                        organizacionVinculada.Direccion = reader.GetString(2);
                        organizacionVinculada.Email = reader.GetString(3);
                        organizacionVinculada.NombreOrganizacion = reader.GetString(4);
                        organizacionVinculada.Telefono = reader.GetString(5);

                        organizacionesVinculadas.Add(organizacionVinculada);
                    }
                }
                conexionBD.CloseConnection();
            }
            return organizacionesVinculadas;
        }
        
        public OrganizacionVinculada CargarOrganizacionVinculada(int busquedaId)
        {
            ConexionBD conexionBD = new ConexionBD();
            OrganizacionVinculada organizacionVinculada = new OrganizacionVinculada();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM organizacionVinculada WHERE idorganizacionVinculada LIKE @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", busquedaId));

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        organizacionVinculada.IdOrganizacionVinculada = reader.GetInt32(0);
                        organizacionVinculada.Ciudad = reader.GetString(1);
                        organizacionVinculada.Direccion = reader.GetString(2);
                        organizacionVinculada.Email = reader.GetString(3);
                        organizacionVinculada.NombreOrganizacion = reader.GetString(4);
                        organizacionVinculada.Telefono = reader.GetString(5);
                    }
                }
                conexionBD.CloseConnection();
            }
            return organizacionVinculada;
        }

        public void DarDeBajaOrganizacion(int busquedaId)
        {
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM WHERE LIKE @busqueda"))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", busquedaId));

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

        public void GuardarOrganizacionVinculada(OrganizacionVinculada nuevaOrganizacionVinculada)
        {
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO  VALUES (@id, @ciudad, @direccion, @email, @nombreOrganizacion, @telefono)"))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("id", null));
                    sqlCommand.Parameters.Add(new SqlParameter("ciudad", nuevaOrganizacionVinculada.Ciudad));
                    sqlCommand.Parameters.Add(new SqlParameter("direccion", nuevaOrganizacionVinculada.Direccion));
                    sqlCommand.Parameters.Add(new SqlParameter("email", nuevaOrganizacionVinculada.Email));
                    sqlCommand.Parameters.Add(new SqlParameter("nombreOrganizacion", nuevaOrganizacionVinculada.NombreOrganizacion));
                    sqlCommand.Parameters.Add(new SqlParameter("telefono", nuevaOrganizacionVinculada.Telefono));

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

        public void ModificarCiudadOrganizacion(string nuevaCiudad, int busquedaId)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE organizacionVinculada SET Ciudad = @actualizacion WHERE idorganizacionVinculada = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevaCiudad));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", busquedaId));

                    try
                    {
                        sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                conexionBD.CloseConnection();
            }
        }

        public void ModificarDireccionOrganizacion(string nuevaDireccion, int busquedaId)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE organizacionVinculada SET Direccion = @actualizacion WHERE idorganizacionVinculada = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevaDireccion));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", busquedaId));

                    try
                    {
                        sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                conexionBD.CloseConnection();
            }
        }

        public void ModificarEmailOrganziacion(string nuevoEmail, int busquedaId)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE organizacionVinculada SET Email = @actualizacion WHERE idorganizacionVinculada = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoEmail));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", busquedaId));

                    try
                    {
                        sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                conexionBD.CloseConnection();
            }
        }

        public void ModificarNombreOrganixacion(string nuevoNombre, int busquedaId)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE organizacionVinculada SET nombreOrganizacion = @actualizacion WHERE idorganizacionVinculada = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoNombre));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", busquedaId));

                    try
                    {
                        sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                conexionBD.CloseConnection();
            }
        }

        public void ModificarTelefonoOrganizacion(string nuevoTelefono, int busquedaId)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE organizacionVinculada SET Telefono = @actualizacion WHERE idorganizacionVinculada = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoTelefono));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", busquedaId));

                    try
                    {
                        sqlCommand.ExecuteReader();
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
