using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    interface ITecnicoAcademicoDAO
    {
        void GuardarTecnicoAcademico(TecnicoAcademico nuevoTecnicoAcademico);
        List<TecnicoAcademico> CargarTecnicosAcademicos();
        TecnicoAcademico CargarTecnicoAcademico(string busquedaNombre);
        void ModificarNombre(string nuevoNombre, int idTecnico);
        void ModificarApellidoPaterno(string nuevoApellido, int idTecnico);
        void ModificarApellidoMaterno(string nuevoApellido, int idTecnico);
        void ModificarCorreo(string nuevoEmail, int idTecnico);
        void ModificarNumeroPersonal(int nuevoNumero, int idTecnico);
        void ModificarTelefono(string nuevoTelefono, int idTecnico);
    }
}
