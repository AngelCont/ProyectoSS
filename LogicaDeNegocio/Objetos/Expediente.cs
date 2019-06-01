using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Objetos
{
    public class Expediente
    {
        public int IdExpediente { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public int HorasRegistradas { get; set; }
        public int IdAlumno { get; set; }
        public int IdProyecto { get; set; }
        public List<Reporte> Reportes { get; set; }
        public List<Documento> Documentos { get; set; }
    }
}
