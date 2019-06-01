using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    public class ProgramaEducativo
    {
        public int IdProgramaEducativo { get; set; }
        public string ClavePrograma { get; set; }
        public string NombrePrograma { get; set; }
        public int IdTecnicoAcademico { get; set; }
        public int IdCoordinador { get; set; }
    }
}
