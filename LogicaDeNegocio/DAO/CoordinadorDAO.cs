using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDeDatos;
using System.Data.SqlClient;
using LogicaDeNegocio.Objetos;
using LogicaDeNegocio.Interfaces;

namespace LogicaDeNegocio
{
    public class CoordinadorDAO : ICoordinadorDAO
    {
        public List<Coordinador> CargarCoordinadores()
        {
            List<Coordinador> coordinadores = new List<Coordinador>();
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Coordinador", sqlConnection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Coordinador coordinador = new Coordinador();

                        coordinador.IdCoordinador = reader.GetInt32(0);
                        coordinador.Nombre = reader.GetString(1);
                        coordinador.ApellidoPaterno = reader.GetString(2);
                        coordinador.ApellidoMaterno = reader.GetString(3);
                        coordinador.Correo = reader.GetString(4);
                        coordinador.NumeroDePersonal = reader.GetInt32(5);
                        coordinador.Telefono = reader.GetString(6);

                        coordinadores.Add(coordinador);
                    }
                }
                conexionBD.CloseConnection();
            }
            return coordinadores;
        }

        public Coordinador CargarCoordinadorPorNumeroPersonal(int numeroDePersonal)
        {
            Coordinador coordinador = new Coordinador();
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Coordinador WHERE idCoordinador = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", numeroDePersonal));
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        coordinador.IdCoordinador = reader.GetInt32(0);
                        coordinador.Nombre = reader.GetString(1);
                        coordinador.ApellidoPaterno = reader.GetString(2);
                        coordinador.ApellidoMaterno = reader.GetString(3);
                        coordinador.Correo = reader.GetString(4);
                        coordinador.NumeroDePersonal = reader.GetInt32(5);
                        coordinador.Telefono = reader.GetString(6);
                    }
                }
                conexionBD.CloseConnection();
            }
            return coordinador;
        }

        public void DarDeBajaCoordinador(int idCoordinador)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Coordinador WHERE idCoordinador = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idCoordinador));

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

        public void GuardarCoordinador(Coordinador nuevoCoordinador)
        {
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("INSERT INTO Coordinador VALUES (@id, @nombreCoordinador, @apellidoPCoordinador, @apellidoMCoordinador, @email, @numeroPersonal, @telefonoCoordinador)", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("id", null));
                    sqlCommand.Parameters.Add(new SqlParameter("nombreCoordinador", nuevoCoordinador.Nombre));
                    sqlCommand.Parameters.Add(new SqlParameter("apellidoPCoordinador", nuevoCoordinador.ApellidoPaterno));
                    sqlCommand.Parameters.Add(new SqlParameter("apellidoMCoordinador", nuevoCoordinador.ApellidoMaterno));
                    sqlCommand.Parameters.Add(new SqlParameter("email", nuevoCoordinador.Correo));
                    sqlCommand.Parameters.Add(new SqlParameter("numeroPersonal", nuevoCoordinador.NumeroDePersonal));
                    sqlCommand.Parameters.Add(new SqlParameter("telefonoCoordinador", nuevoCoordinador.Telefono));

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

        public void ModificarApellidoMaterno(string nuevoApellidoMaterno, int idCoordinador)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Coordinador SET apellidoMaterno = @actualizacion WHERE idCoordinador = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoApellidoMaterno));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idCoordinador));

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

        public void ModificarApellidoPaterno(string nuevoApellidoPaterno, int idCoordinador)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Coordinador SET apellidoPaterno = @actualizacion WHERE idCoordinador = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoApellidoPaterno));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idCoordinador));

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

        public void ModificarCorreo(string nuevoEmail, int idCoordinador)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Coordinador SET Correo = @actualizacion WHERE idCoordinador = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoEmail));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idCoordinador));

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

        public void ModificarNombre(string nuevoNombre, int idCoordinador)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Coordinador SET Nombre = @actualizacion WHERE idCoordinador = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoNombre));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idCoordinador));

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

        public void ModificarNumeroDePersonal(string nuevoNumeroDePersonal, int idCoordinador)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Coordinador SET numerodePersonal = @actualizacion WHERE idCoordinador = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoNumeroDePersonal));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idCoordinador));

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

        public void ModificarTelefono(string nuevoTelefono, int idCoordinador)
        {
            ConexionBD conexionBD = new ConexionBD();

            using (SqlConnection sqlConnection = conexionBD.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Coordinador SET Telefono = @actualizacion WHERE idCoordinador = @busqueda", sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("actualizacion", nuevoTelefono));
                    sqlCommand.Parameters.Add(new SqlParameter("busqueda", idCoordinador));

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
