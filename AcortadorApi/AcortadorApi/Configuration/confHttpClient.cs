using AcortadorApi.Repositorios;
using System.Net.Http.Headers;

namespace AcortadorApi.Configuration
{
    public static class confHttpClient
    {
        public static IHttpClientBuilder AddConfRepositorioHTTP(this IServiceCollection services, ConfigurationManager configuration)
        {

            return services.AddHttpClient<IRepositorio, Repositorio>((serviceProvider, options) =>
            {
                var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();

                if (httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated)
                {
                    var token = httpContextAccessor.HttpContext!.Request.Headers["Authorization"].FirstOrDefault()!.Split(' ')[1];
                    options.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }



                options.BaseAddress = new Uri(configuration["endpointAcceso"]);

            });



        }
    }
}
