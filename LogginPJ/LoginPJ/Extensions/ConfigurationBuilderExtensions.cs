namespace LogginPJ.Extensions;
public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddConfigurationFile(this IConfigurationBuilder source,
        string configFileName = "appsettings",
        bool loadBaseFile = true,
        bool optional = true,
        string customDirectory = default)
    {
        var enviroment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var result = source.SetBasePath(customDirectory ?? Directory.GetCurrentDirectory());

        if (loadBaseFile)
            result = result.AddJsonFile($"{configFileName}.json", optional: optional, reloadOnChange: true);

        return result.AddJsonFile($"{configFileName}.{enviroment}.json", optional: optional, reloadOnChange: true);
    }
}

