using LoggerManager;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace RaouleBackEnd.Extensions
{
    public static class MigrationManagerExtension
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        var logger = scope.ServiceProvider.GetRequiredService<HRLoggerManager>();
                        logger?.LogError(ex.Message);
                        throw;
                    }
                }
            }
            return webApp;
        }
    }
}
