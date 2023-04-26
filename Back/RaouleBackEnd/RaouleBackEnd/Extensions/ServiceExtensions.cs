using Contracts;
using LoggerManager;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Service;
using Service.Contracts;

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
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, HRLoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
    services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

}
}
