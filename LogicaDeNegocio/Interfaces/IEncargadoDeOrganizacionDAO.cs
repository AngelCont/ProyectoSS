using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    interface IEncargadoDeOrganizacionDAO
    {
        void GuardarEncargadoDeOrganizacion(EncargadoDeOrganizacion nuevoEncargadoDeOrganizacion);
        EncargadoDeOrganizacion CargarEncargadoDeOrganizacion(int idOctanizacion);
    }
}
