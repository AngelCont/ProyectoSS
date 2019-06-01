using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDeDatos;
using LogicaDeNegocio.Interfaces;
using LogicaDeNegocio.Objetos;

namespace LogicaDeNegocio
{
    public class AlumnoDAO : IAlumnoDAO
    {
        public void GuardarAlumno(Alumno nuevoAlumno)
        {
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Alumno VALUES(@id, @nombreAlumno, @apellidoPAlumno, @apellidoMAlumno, @matricula, @idProyecto, @idExpediente)", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("id", null));
                    sqlCommand.Parameters.Add(new SqlParameter("nombreAlumno", nuevoAlumno.Nombre));
                    sqlCommand.Parameters.Add(new SqlParameter("apellidoPAlumno", nuevoAlumno.ApellidoPaterno));
                    sqlCommand.Parameters.Add(new SqlParameter("apellidoMalumno", nuevoAlumno.ApellidoMaterno));
                    sqlCommand.Parameters.Add(new SqlParameter("matricula", nuevoAlumno.Matricula));
                    sqlCommand.Parameters.Add(new SqlParameter("proyecto", null));
                    sqlCommand.Parameters.Add(new SqlParameter("expediente", null));

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

        public List<Alumno> CargarAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Alumno", sqlConnection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Alumno alumno = new Alumno();
                        alumno.IdAlumno = reader.GetInt32(0);
                        alumno.Nombre = reader.GetString(1);
                        alumno.ApellidoPaterno = reader.GetString(2);
                        alumno.ApellidoMaterno = reader.GetString(3);
                        alumno.Matricula = reader.GetString(4);
                        alumno.IdProyecto = reader.GetInt32(5);
                        alumno.IdExpediente = reader.GetInt32(6);

                        alumnos.Add(alumno);
                    }
                }
                conexionBD.CloseConnection();
            }
            return alumnos;
        }

        public Alumno CargarAlumnoPorMatricula(string matricula)
        {
            Alumno alumno = new Alumno();
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Alumno WHERE Matricula = @busqueda", sqlConnection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        alumno.IdAlumno = reader.GetInt32(0);
                        alumno.Nombre = reader.GetString(1);
                        alumno.ApellidoPaterno = reader.GetString(2);
                        alumno.ApellidoMaterno = reader.GetString(3);
                        alumno.Matricula = reader.GetString(4);
                        alumno.IdProyecto = reader.GetInt32(5);
                        alumno.IdExpediente = reader.GetInt32(6);
                    }
                }
                conexionBD.CloseConnection();
            }
            return alumno;
        }

        public void EliminarAlumno(int idAlumno)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Alumno WHERE idAlumno = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idAlumno));

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

        public void ModificarNombre(string nuevoNombre, int idAlumno)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Alumno SET Nombre = @actualizacion WHERE idAlumno = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoNombre));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idAlumno));

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

        public void ModificarApellidoPaterno(string nuevoApellidoPaterno, int idAlumno)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Alumno SET apellidoPaterno = @actualizacion WHERE idAlumno = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoApellidoPaterno));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idAlumno));

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

        public void ModificarApellidoMaterno(string nuevoApellidoMaterno, int idAlumno)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Alumno SET apellidoMaterno = @actualizacion WHERE idAlumno = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoApellidoMaterno));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idAlumno));

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

        public void ModificarMatricula(string nuevaMatricula, int idAlumno)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Alumno SET Matricula = @actualizacion WHERE idAlumno = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevaMatricula));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idAlumno));

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

        public void AsignarProyecto(int idProyecto, int idAlumno)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Alumno SET FK_idProyeccto = @proyecto WHERE idAlumno = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", idProyecto));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idAlumno));

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

        public void AsignarExpediente(int idExpediente, int idAlumno)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Alumno SET FK_idExpediente = @expediente WHERE idAlumno = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", idExpediente));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idAlumno));

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
