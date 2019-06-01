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
        Alumno recuperarAlumno(String matricula);
        void cambiarEstadoDeAlumno(int idAlumno,int idEstado);
        void eliminarAlumno(int idAlumno);
        void actualizarDatosDeAlumno(Alumno alumno);
        void registrarAlumno(Alumno alumno);
    }
}
