using Microsoft.Extensions.Configuration;

namespace Common
{
    public class DatabaseConnection<T>
        where T : class
    {
        public static string Get()
        {
            var secretConfig = new ConfigurationBuilder()
                .AddUserSecrets<T>()
                .Build();
            return secretConfig["connectionstring"];
        }
    }
}