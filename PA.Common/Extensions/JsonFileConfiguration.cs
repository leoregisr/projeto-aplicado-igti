using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace PA.Common.Extensions
{
	public static class JsonFileConfiguration
    {

        private static IConfigurationRoot _config;

        public static IConfigurationRoot Get(bool userEnvironmentVariables = true)
        {
            if (_config != null)
                return _config;

            var executionPath = Assembly.GetExecutingAssembly().Location;
            FileInfo file = new FileInfo(executionPath);

            var conf = new ConfigurationBuilder()
                .SetBasePath(file.Directory.FullName)
                .AddJsonFile("appsettings.json");

            if (userEnvironmentVariables)
                conf.AddEnvironmentVariables();

            return _config = conf.Build();
        }
    }
}