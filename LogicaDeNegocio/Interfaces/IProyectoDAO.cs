using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    interface IProyectoDAO
    {
        void GuardarNuevoProyecto(Proyecto nuevoProyecto);
        List<Proyecto> CargarProyectos();
        Proyecto CargarProyecto(int idProyecto);
        void ModificarNombre(string nuevoNombre, int idPropyecto);
        void ModificarResponsable(string nuevoResponsable, int idProyecto);
        void ModificarCupo(int nuevoCupo, int idProyecto);
        void ModificarDescripcionGeneral(string nuevaDescripcion, int idProyecto);
        void ModificarObjetivoGeneral(string nuevoObjetivo, int idProyecto);
        void ModificarResponsabilidad(string nuevaResponsabilidad, int idProyecto);
        void ModificarPoblacionAtendida(string nuevaPoblacion, int idProyecto);
        void ModificarHorario(int nuevaHoraInicio, int nuevaHoraFin, int idProyecto);
        void ModificarDuracion(DateTime nuevaFechaInicio, DateTime nuevaFechaFin, int idProyecto);

    }
}
