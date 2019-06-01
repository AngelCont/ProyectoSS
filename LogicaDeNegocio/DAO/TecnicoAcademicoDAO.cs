using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDeDatos;
using System.Data.SqlClient;

namespace LogicaDeNegocio
{
    public class TecnicoAcademicoDAO : ITecnicoAcademicoDAO
    {
        public TecnicoAcademico CargarTecnicoAcademico(string busquedaNombre)
        {
            throw new NotImplementedException();
        }

        public List<TecnicoAcademico> CargarTecnicosAcademicos()
        {
            throw new NotImplementedException();
        }

        public void GuardarTecnicoAcademico(TecnicoAcademico nuevoTecnicoAcademico)
        {
            throw new NotImplementedException();
        }

        public void ModificarApellidoMaterno(string nuevoApellido, int idTecnico)
        {
            throw new NotImplementedException();
        }

        public void ModificarApellidoPaterno(string nuevoApellido, int idTecnico)
        {
            throw new NotImplementedException();
        }

        public void ModificarCorreo(string nuevoEmail, int idTecnico)
        {
            throw new NotImplementedException();
        }

        public void ModificarNombre(string nuevoNombre, int idTecnico)
        {
            throw new NotImplementedException();
        }

        public void ModificarNumeroPersonal(int nuevoNumero, int idTecnico)
        {
            throw new NotImplementedException();
        }

        public void ModificarTelefono(string nuevoTelefono, int idTecnico)
        {
            throw new NotImplementedException();
        }
    }
}
