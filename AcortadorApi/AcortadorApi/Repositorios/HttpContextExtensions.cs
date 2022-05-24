using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AcortadorApi.Repositorios
{
    public static class HttpContextExtensions
    {
        public async static Task insterarparametrospaginacionrespesta<T>(this HttpContext context,
            IQueryable<T> queryable, int cantidadderegistro)
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            double conteo = await queryable.CountAsync();
            double totalPaginas = Math.Ceiling(conteo / cantidadderegistro);
            context.Response.Headers.Add("conteo", conteo.ToString());
            context.Response.Headers.Add("totalPaginas", totalPaginas.ToString()); ;
        }
    }
}
