using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Objetos
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String Matricula { get; set; }
        public int IdProyecto { get; set; }
        public int IdExpediente { get; set; }
        public String CorreoElectronico { get; set; }
        public int Estado { get; set; }
    }
}
