using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Objetos
{
    public class Reporte
    {
        public int IdReporte { get; set; }
        public String Actividad{ get; set; }
        public Byte[] Archivo { get; set; }
        public DateTime Fecha { get; set; }
        public int HorasRegistradaas { get; set; }
        public int IdExpediente { get; set; }
    }
}
