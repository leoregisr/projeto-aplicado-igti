using System;
using System.Reflection;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PA.Common.Mapper;

namespace PA.Common.Extensions
{
	public static class MapperExtensions
    {
        public static T Map<T>(this object source)
        {
            return SingletonMapper.Mapper.Map<T>(source);
        }

        public static void Map(this object target, object source)
        {
            SingletonMapper.Mapper.Map(source, target);
        }

        public static IMappingExpression IgnoreAllNonExisting(this IMappingExpression expression)
        {
            var mappingExpression = (MappingExpression)expression;
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var destinationProperties = mappingExpression.Types.DestinationType.GetProperties(flags);

            foreach (var property in destinationProperties)
            {
                if (mappingExpression.Types.SourceType.GetProperty(property.Name, flags) != null) continue;
                expression.ForMember(property.Name, opt => opt.Ignore());
            }
            return expression;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            return services.AddSingleton(mapper)
                .AddSingleton<SingletonMapper>(new SingletonMapper(mapper));
        }


        public static IServiceCollection AddMap<T, TD>(this IServiceCollection services)
        {
            SingletonMapper.Maps.Add(new Tuple<Type, Type>(typeof(T), typeof(TD)));
            return services;
        }

    }
}