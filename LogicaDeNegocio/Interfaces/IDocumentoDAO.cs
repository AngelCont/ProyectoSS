using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Objetos;

namespace LogicaDeNegocio.Interfaces
{
    interface IDocumentoDAO
    {
        List<Documento> recuperarListaDeDocumentos(int idExpediente);
        void registrarDocumento(Documento documento);
        void eliminarDocumento(int idDocumento);
    }
}
