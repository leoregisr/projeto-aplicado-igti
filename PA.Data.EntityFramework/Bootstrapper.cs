using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PA.Core.Domain.Repositories;
using PA.Data.Repositories.EntityFramework.DbContext;
using PA.Data.Repositories.EntityFramework.EF;
using PA.Data.Repositories.EntityFramework.Repositories;

namespace PA.Data.Repositories.EntityFramework
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<UserDataDbContext>((options) => options.UseSqlServer());

            services.AddDbContextPool<ApplicationDataDbContext>((options) => options.UseSqlServer());

            services
                .AddScoped<IDbContext, UserDataDbContext>()
                .AddScoped<IDbContext, ApplicationDataDbContext>()
                .AddScoped<ITransactionManager, TransactionManager>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ITimeCardRepository, TimeCardRepository>()
                .AddScoped<IProjectRepository, ProjectRepository>()
                .AddScoped<IClientRepository, ClientRepository>();
            
            return services;
        }
    }
}