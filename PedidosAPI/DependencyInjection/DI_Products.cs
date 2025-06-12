using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.EntityFrameworkCore;
using PedidosAPI.Data;

namespace PedidosAPI.DependencyInjection
{
    public static class DI_Products
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<ILoggingService, LoggingService>();            
            services.AddDbContext<ProductContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MasterConnection"));
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
