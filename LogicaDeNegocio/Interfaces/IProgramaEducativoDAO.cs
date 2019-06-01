using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    interface IProgramaEducativoDAO
    {
        void GuardarNuevoProgramaEducativo(ProgramaEducativo nuevoProgramaEducativo);
        List<ProgramaEducativo> CargarListaProgramaEducativo();
        ProgramaEducativo CargarProgramaEducativo(int busquedaId);
        void DarDeBajaProgramaEducativo(int busquedaId);
    }
}
