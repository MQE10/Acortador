using AcortadorApi.Data;
using Microsoft.EntityFrameworkCore;

namespace AcortadorApi.Configuration
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddConfDbContextLog(this IServiceCollection services, ConfigurationManager configuration)
        {

            return services.AddDbContext<UpdsLogContext>(
       options => options.UseSqlServer(configuration.GetConnectionString("Log")));

        }

        public static IServiceCollection AddConfDbContextSAADS(this IServiceCollection services, ConfigurationManager configuration)
        {

            return services.AddDbContext<SAADSContext>((serviceProvider, dbContextBuilder) =>
            {
                var connectionStringPlaceHolder = configuration.GetConnectionString("SAADS");
                var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
                var dbName = httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(a => a.Type == "tenantId")!.Value;
                var connectionString = connectionStringPlaceHolder.Replace("{dbName}", dbName);
                dbContextBuilder.UseSqlServer(connectionString);
            });

        }
    }
}
