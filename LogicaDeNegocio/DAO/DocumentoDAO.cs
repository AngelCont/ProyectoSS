using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Interfaces;
using LogicaDeNegocio.Objetos;
using System.Data.SqlClient;
using System.Data;
using AccesoDeDatos;

namespace LogicaDeNegocio.DAO
{
    class DocumentoDAO : IDocumentoDAO
    {
        public void eliminarDocumento(int idDocumento)
        {
            throw new NotImplementedException();
        }

        public List<Documento> recuperarListaDeDocumentos(int idExpediente)
        {
            ConexionBD acceso = new ConexionBD();
            List<Documento> listaDeDocumentos = new List<Documento>();
            Documento documento = new Documento();
            using (SqlConnection sqlConnection = acceso.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT idDocumento,idExpediente,archivo,fechaEntrega FROM documento WHERE idExpediente = @idExpediente"))
                {
                    sqlCommand.Parameters.Add("@idExpediente", SqlDbType.Int);
                    sqlCommand.Parameters["@idExpediente"].Value = idExpediente;
                    try
                    {
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            documento.IdDocumento = reader.GetInt32(0);
                            documento.IdExpediente = reader.GetInt32(1);
                            documento.Archivo = (byte[])reader.GetValue(2);
                            documento.Fecha = reader.GetDateTime(3);
                            listaDeDocumentos.Add(documento);
                        }
                    }
                    catch (SqlException sqlException)
                    {
                        Console.WriteLine(sqlException.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            return listaDeDocumentos;
        }

        public void registrarDocumento(Documento documento)
        {
            throw new NotImplementedException();
        }
    }
}
