using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Objetos;

namespace LogicaDeNegocio.Interfaces
{
    interface ICoordinadorDAO
    {
        List<Coordinador> CargarCoordinadores();
        Coordinador CargarCoordinadorPorNumeroPersonal(int numeroDePersonal);
        void DarDeBajaCoordinador(int idCoordinador);
        void GuardarCoordinador(Coordinador nuevoCoordinador);
        void ModificarApellidoMaterno(string nuevoApellidoMaterno, int idCoordinador);
        void ModificarApellidoPaterno(string nuevoApellidoPaterno, int idCoordinador);
        void ModificarNombre(string nuevoNombre, int idCoordinador);
        void ModificarNumeroDePersonal(string nuevoNumeroDePersonal, int idCoordinador);
        void ModificarTelefono(string nuevoTelefono, int idCoordinador);
    }
}
