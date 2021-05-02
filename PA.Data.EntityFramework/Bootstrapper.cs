using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PA.Data.Repositories.EntityFramework
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<UserDataDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("UserDataConnection")));

            services.AddDbContextPool<ApplicationDataDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}