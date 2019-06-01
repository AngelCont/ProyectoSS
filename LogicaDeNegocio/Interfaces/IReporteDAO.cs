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
        Reporte CargarReporte();
        List<Reporte> CargarReportes();
        List<Reporte> CargarReportesPorMatricula(string matricula);
        void GuardarReporte(Reporte nuevoReporte);
    }
}
