using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Objetos;

namespace LogicaDeNegocio.Interfaces
{
    interface ICoordinadorDeServicioSocialDAO
    {
        Coordinador recuperarDatos(int numeroDePersonal);
        List<Coordinador> recuperarListaDeCoordinadores();
        void cambiarEstado(Coordinador coordinador);
        void actualizarDatosBasicos(Coordinador coordinador);
        void registrarCoordinador(Coordinador coordinador);
        
    }
}
