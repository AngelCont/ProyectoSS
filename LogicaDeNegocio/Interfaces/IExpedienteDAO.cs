using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Objetos;

namespace LogicaDeNegocio.Interfaces
{
    interface IExpedienteDAO
    {
        Expediente recuperarExpedienteDeAlumno(int idAlumno);
        void registrarExpediente(Expediente expediente);
        void modificarExpediente(Expediente expediente);
        void desasignarProyecto(int idAlumno);
        void eliminarExpediente(int idExpediente);
    }
}
