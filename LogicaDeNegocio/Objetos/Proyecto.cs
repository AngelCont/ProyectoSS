using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class Proyecto
    {
        public int IdProyecto { get; set; }
        public int Cupo { get; set; }
        public string DescripcionGeneral { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }
        public string NombreProyecto { get; set; }
        public string ObjetivoGeneral { get; set; }
        public string PoblacionAtendida { get; set; }
        public string Responsabilidad { get; set; }
        public int IdEncargadoDeOrganizacion { get; set; }
    }
}
