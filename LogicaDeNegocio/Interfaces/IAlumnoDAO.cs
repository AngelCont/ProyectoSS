using LogicaDeNegocio.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Interfaces
{
    interface IAlumnoDAO
    {
        void GuardarAlumno(Alumno nuevoAlumno);
        List<Alumno> CargarAlumnos();
        Alumno CargarAlumnoPorMatricula(string matricula);
        void EliminarAlumno(int idAlumno);
        void ModificarNombre(string nuevoNombre, int idAlumno);
        void ModificarApellidoPaterno(string nuevoApellidoPaterno, int idAlumno);
        void ModificarApellidoMaterno(string nuevoApellidoMaterno, int idAlumno);
        void ModificarMatricula(string nuevaMatricula, int idAlumno);
        void AsignarProyecto(int idProyecto, int idAlumno);
        void AsignarExpediente(int idExpediente, int idAlumno);
    }
}
