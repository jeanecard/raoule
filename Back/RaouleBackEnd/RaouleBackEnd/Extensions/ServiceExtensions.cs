using Microsoft.EntityFrameworkCore;
using Repositories;

namespace RaouleBackEnd.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
        opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
            (sqlServer) =>
            {
                sqlServer.MigrationsAssembly("RaouleBackEnd");
                sqlServer.UseNetTopologySuite();
            }));

    }
}
