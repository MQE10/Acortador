using Microsoft.AspNetCore.Components.Authorization;
using Proyecto1.DTOs;
using Proyecto1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Proyecto1.Helpers
{
    public static class DatosUsuarioLogueado
    {
        public static DatosUsuarios? CargarDatosUsuario(AuthenticationState authenticationState)
        {
            var authState = authenticationState;
            var user = authState.User;


            if (user.Identity!.IsAuthenticated)
            {

                int sedeId = int.Parse(user.Claims.FirstOrDefault(a => a.Type == "sedeId")!.Value);
                long expiracion = long.Parse(user.Claims.FirstOrDefault(b => b.Type == "expiracion")!.Value);

                var expiracionToken = expiracion.UnixTimeToDateTime();




                var timeZone = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(x => x.Id == "SA Western Standard Time");

                var datoUsuario = new DatosUsuarios
                {
                    NombreUsuario = user.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name)!.Value,
                    Correo = user.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)!.Value,
                    UserId = long.Parse(user.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)!.Value),
                    SedeId = sedeId,
                    ExpiraccionToken = expiracionToken,

                };

                return datoUsuario;

            }

            return null;
        }
    }
}
