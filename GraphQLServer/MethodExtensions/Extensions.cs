using GraphQLServer.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServer.MethodExtensions
{
    public static class Extensions
    {
        public static async Task ConfigureMigrationsAsync(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = services.GetRequiredService<BlogContext>();
                await context.Database.MigrateAsync();
                await BlogContextSeed.SeedAsync(context, loggerFactory);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Ocurrio un error durante la migración!");
            }
        }
    }
}
