using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio
{
    interface IOrganizacionVinculadaDAO
    {
        void GuardarOrganizacionVinculada(OrganizacionVinculada nuevaOrganizacionVinculada);
        List<OrganizacionVinculada> CargarListaOrganizacionVinculada();
        OrganizacionVinculada CargarOrganizacionVinculada(int idOrganizacion);
        void ModificarNombreOrganixacion(string nuevoNombre, int idOrganizacion);
        void ModificarCiudadOrganizacion(string nuevaCiudad, int idOrganizacion);
        void ModificarDireccionOrganizacion(string nuevaDireccion, int idOrganizacion);
        void ModificarEmailOrganziacion(string nuevoEmail, int idOrganizacion);
        void ModificarTelefonoOrganizacion(string nuevoTelefono, int idOrganizacion);
        void DarDeBajaOrganizacion(int idOrganizacion);
    }
}
