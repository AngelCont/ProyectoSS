using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    interface IDiaAtencionDAO
    {
        DiaAtencion CargarDiaAtencion(int idTecnico);
        void GuardarNuevoDiaAtencion(DiaAtencion nuevoDiaAtención);
    }
}
