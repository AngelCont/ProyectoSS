using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDeDatos;
using System.Data.SqlClient;

namespace LogicaDeNegocio
{
    public class ProyectoDAO : IProyectoDAO
    {
        public Proyecto CargarProyecto(int idProyecto)
        {
            ConexionBD conexionBD = new ConexionBD();
            Proyecto proyecto = new Proyecto();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Proyecto WHERE idProyecto = @proyecto", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("proyecto", idProyecto));
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        proyecto.IdProyecto = reader.GetInt32(0);
                        proyecto.Cupo = reader.GetInt32(1);
                        proyecto.DescripcionGeneral = reader.GetString(2);
                        proyecto.FechaInicio = reader.GetDateTime(3);
                        proyecto.FechaFin = reader.GetDateTime(4);
                        proyecto.HoraInicio = reader.GetInt32(5);
                        proyecto.HoraFin = reader.GetInt32(6);
                        proyecto.NombreProyecto = reader.GetString(7);
                        proyecto.ObjetivoGeneral = reader.GetString(8);
                        proyecto.PoblacionAtendida = reader.GetString(9);
                        proyecto.Responsabilidad = reader.GetString(10);
                        proyecto.IdEncargadoDeOrganizacion = reader.GetInt32(11);
                    }
                }
                conexionBD.CloseConnection();
            }
            return proyecto;
        }

        public List<Proyecto> CargarProyectos()
        {
            ConexionBD conexionBD = new ConexionBD();
            List<Proyecto> proyectos = new List<Proyecto>();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Proyecto", sqlConnection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Proyecto proyecto = new Proyecto();

                        proyecto.IdProyecto = reader.GetInt32(0);
                        proyecto.Cupo = reader.GetInt32(1);
                        proyecto.DescripcionGeneral = reader.GetString(2);
                        proyecto.FechaInicio = reader.GetDateTime(3);
                        proyecto.FechaFin = reader.GetDateTime(4);
                        proyecto.HoraInicio = reader.GetInt32(5);
                        proyecto.HoraFin = reader.GetInt32(6);
                        proyecto.NombreProyecto = reader.GetString(7);
                        proyecto.ObjetivoGeneral = reader.GetString(8);
                        proyecto.PoblacionAtendida = reader.GetString(9);
                        proyecto.Responsabilidad = reader.GetString(10);
                        proyecto.IdEncargadoDeOrganizacion = reader.GetInt32(11);

                        proyectos.Add(proyecto);
                    }
                }
                conexionBD.CloseConnection();
            }
            return proyectos;
        }

        public void GuardarNuevoProyecto(Proyecto nuevoProyecto)
        {
            ConexionBD conexionBD = new ConexionBD();
            
            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Proyecto VALUES (@id, @cupoProyecto, @descripcion, @fechaInicial, @fechaFinal, @horaInicial, @horaFinal, @nombreProyecto, @objetivo, @poblacion, @resonsabilidadProyecto, @idEncargado)"))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("id", null));
                    sqlCommand.Parameters.Add(new SqlParameter("cupoProyecto", nuevoProyecto.Cupo));
                    sqlCommand.Parameters.Add(new SqlParameter("descripcion", nuevoProyecto.DescripcionGeneral));
                    sqlCommand.Parameters.Add(new SqlParameter("fechaInicial", nuevoProyecto.FechaInicio));
                    sqlCommand.Parameters.Add(new SqlParameter("fechaFinal", nuevoProyecto.FechaFin));
                    sqlCommand.Parameters.Add(new SqlParameter("horaInicial", nuevoProyecto.HoraInicio));
                    sqlCommand.Parameters.Add(new SqlParameter("horaFinal", nuevoProyecto.HoraFin));
                    sqlCommand.Parameters.Add(new SqlParameter("nombreProyecto", nuevoProyecto.NombreProyecto));
                    sqlCommand.Parameters.Add(new SqlParameter("objetivo", nuevoProyecto.ObjetivoGeneral));
                    sqlCommand.Parameters.Add(new SqlParameter("poblacion", nuevoProyecto.PoblacionAtendida));
                    sqlCommand.Parameters.Add(new SqlParameter("resonsabilidadProyecto", nuevoProyecto.Responsabilidad));
                    sqlCommand.Parameters.Add(new SqlParameter("idEncargado", nuevoProyecto.IdEncargadoDeOrganizacion));
                    
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

        public void ModificarCupo(int nuevoCupo, int idProyecto)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Proyecto SET Cupo = @actualizacion WHERE idProyecto = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoCupo));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idProyecto));

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

        public void ModificarDescripcionGeneral(string nuevaDescripcion, int idProyecto)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Proyecto SET descripcionGenral = @actualizacion WHERE idProyecto = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevaDescripcion));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idProyecto));

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

        public void ModificarDuracion(DateTime nuevaFechaInicio, DateTime nuevaFechaFin, int idProyecto)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Proyecto SET fechaInicio = @fechaInicial, fechaFin = @fechaFinal WHERE idProyecto = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("fechaInicial", nuevaFechaInicio));
                    sqlCommand.Parameters.Add(new SqlParameter("fechaFinal", nuevaFechaFin));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idProyecto));

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

        public void ModificarHorario(int nuevaHoraInicio, int nuevaHoraFin, int idProyecto)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Proyecto SET horaInicio = @horaInicial, horaFin = @horaFinal WHERE idProyecto = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("horaInicial", nuevaHoraInicio));
                    sqlCommand.Parameters.Add(new SqlParameter("horaFinal", nuevaHoraFin));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idProyecto));

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

        public void ModificarNombre(string nuevoNombre, int idProyecto)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Proyecto SET Nombre = @actualizacion WHERE idProyecto = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoNombre));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idProyecto));

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

        public void ModificarObjetivoGeneral(string nuevoObjetivo, int idProyecto)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Proyecto SET objetivoGeneral = @actualizacion WHERE idAlumno = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoObjetivo));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idProyecto));

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

        public void ModificarOrganizacion(string nuevaOrganizacion, int idProyecto)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Proyecto SET FK_idencargadodeOrganizacion = @actualizacion WHERE idAlumno = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevaOrganizacion));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idProyecto));

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

        public void ModificarPoblacionAtendida(string nuevaPoblacion, int idProyecto)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Proyecto SET poblacionAtendida = @actualizacion WHERE idAlumno = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevaPoblacion));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idProyecto));

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

        public void ModificarResponsabilidad(string nuevaResponsabilidad, int idProyecto)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Proyecto SET FK_idencargadodeOrganizacion = @actualizacion WHERE idAlumno = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevaResponsabilidad));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idProyecto));

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

        public void ModificarResponsable(string nuevoResponsable, int idProyecto)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Proyecto SET FK_idencargadodeOrganizacion = @actualizacion WHERE idAlumno = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoResponsable));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idProyecto));

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
