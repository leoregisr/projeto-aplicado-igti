using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace PA_API.Configuration
{
    public class CustomConfigProvider : ConfigurationProvider, IConfigurationSource
    {
        public CustomConfigProvider()
        {
        }

        public override void Load()
        {
            Data = UnencryptMyConfiguration();
        }

        private IDictionary<string, string> UnencryptMyConfiguration()
        {
            var configValues = new Dictionary<string, string>
            {
                {"DefaultConnection", "unencryptedValue1"},
                {"UserDataConnection", "unencryptedValue2"}
            };
            return configValues;
        }

        private IDictionary<string, string> CreateAndSaveDefaultValues(IDictionary<string, string> defaultDictionary)
        {
            var configValues = new Dictionary<string, string>
            {
                {"DefaultConnection", "encryptedValue1"},
                {"UserDataConnection", "encryptedValue2"}
            };
            return configValues;                
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new CustomConfigProvider();
        }
    }
}