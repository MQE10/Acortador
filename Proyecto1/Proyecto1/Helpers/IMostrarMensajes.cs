using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Helpers
{
    public interface IMostrarMensajes
    {
        Task MostrarMensajeError(string mensaje);
        Task MostrarMensajeExitoso(string mensaje);
    }
}
