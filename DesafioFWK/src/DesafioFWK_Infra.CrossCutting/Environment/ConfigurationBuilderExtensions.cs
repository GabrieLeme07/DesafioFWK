using Microsoft.Extensions.Configuration;
using System.IO;

namespace DesafioFWK_Infra.CrossCutting.Environment
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddConfigurationFile(this IConfigurationBuilder source,
            string configFileName = "appsettings", bool loadBaseFile = true, bool optional = true)
        {
            var environmentName = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var result = source.SetBasePath(Directory.GetCurrentDirectory());

            if (loadBaseFile)
                result = result
                    .AddJsonFile($"{configFileName}.json", optional: optional, reloadOnChange: true);

            return result
                .AddJsonFile($"{configFileName}.{environmentName}.json",
                    optional: optional, reloadOnChange: true);
        }
    }
}
