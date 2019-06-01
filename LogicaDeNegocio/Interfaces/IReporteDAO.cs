using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Objetos;

namespace LogicaDeNegocio.Interfaces
{
    interface IReporteDAO
    {
        List<Reporte> recuperarListaDeReportes(int idExpediente);
        void registrarReporte(Reporte reporte);
        void modificarReporte(Reporte reporte);
        void eliminarReporte(int idReporte);
    }
}
