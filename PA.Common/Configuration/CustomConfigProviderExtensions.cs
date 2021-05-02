using Microsoft.Extensions.Configuration;

namespace PA.Common.Configuration
{
    public static class CustomConfigProviderExtensions
    {              
        public static IConfigurationBuilder AddEncryptedProvider(this IConfigurationBuilder builder)
        {
            return builder.Add(new CustomConfigProvider());
        }
    }
}