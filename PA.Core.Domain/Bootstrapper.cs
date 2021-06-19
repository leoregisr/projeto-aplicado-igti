using System;
using Microsoft.Extensions.DependencyInjection;
using PA.Common.Extensions;
using PA.Core.Contracts.TransferObjects;
using PA.Core.Domain.Entities;
using PA.Core.Domain.Services;

namespace PA.Core.Domain
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddMap();

            return services.AddScoped<UserService>()
                .AddScoped<TimeCardService>();
        }

        public static IServiceCollection AddMap(this IServiceCollection services)
        {
            return services
                .AddMap<User, UserDto>()
                .AddMap<UserDto, User>()
                .AddMap<TimeCardRegister, TimeCardRegisterDto>()
                .AddMap<TimeCardRegisterDto, TimeCardRegister>()
                .AddMapper();
        }
    }
}
