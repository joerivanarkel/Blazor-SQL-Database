using Microsoft.Extensions.Configuration;

namespace Blazor
{

    public class DatabaseConnection
    {
        public static string Get()
        {
            var secretConfig = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();
            return secretConfig["connectionstring"];
        }
    }
}