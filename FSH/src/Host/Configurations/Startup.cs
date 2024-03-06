namespace FSH.Host.Configurations;

internal static class Startup
{
    internal static WebApplicationBuilder AddConfigurations(this WebApplicationBuilder builder)
    {
        const string configurationsDirectory = "Configurations";
        var env = builder.Environment;
        builder.Configuration.AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
            .AddJsonFile($"{configurationsDirectory}/logger.json", false, true)
            .AddJsonFile($"{configurationsDirectory}/logger.{env.EnvironmentName}.json", true,
                true)
            .AddJsonFile($"{configurationsDirectory}/hangfire.json", false, true)
            .AddJsonFile($"{configurationsDirectory}/hangfire.{env.EnvironmentName}.json", true,
                true)
            .AddJsonFile($"{configurationsDirectory}/cache.json", false, true)
            .AddJsonFile($"{configurationsDirectory}/cache.{env.EnvironmentName}.json", true,
                true)
            .AddJsonFile($"{configurationsDirectory}/cors.json", false, true)
            .AddJsonFile($"{configurationsDirectory}/cors.{env.EnvironmentName}.json", true,
                true)
            .AddJsonFile($"{configurationsDirectory}/database.json", false, true)
            .AddJsonFile($"{configurationsDirectory}/database.{env.EnvironmentName}.json", true,
                true)
            .AddJsonFile($"{configurationsDirectory}/mail.json", false, true)
            .AddJsonFile($"{configurationsDirectory}/mail.{env.EnvironmentName}.json", true,
                true)
            .AddJsonFile($"{configurationsDirectory}/middleware.json", false, true)
            .AddJsonFile($"{configurationsDirectory}/middleware.{env.EnvironmentName}.json", true,
                true)
            .AddJsonFile($"{configurationsDirectory}/security.json", false, true)
            .AddJsonFile($"{configurationsDirectory}/security.{env.EnvironmentName}.json", true,
                true)
            .AddJsonFile($"{configurationsDirectory}/openapi.json", false, true)
            .AddJsonFile($"{configurationsDirectory}/openapi.{env.EnvironmentName}.json", true,
                true)
            .AddJsonFile($"{configurationsDirectory}/signalr.json", false, true)
            .AddJsonFile($"{configurationsDirectory}/signalr.{env.EnvironmentName}.json", true,
                true)
            .AddJsonFile($"{configurationsDirectory}/securityheaders.json", false, true)
            .AddJsonFile($"{configurationsDirectory}/securityheaders.{env.EnvironmentName}.json", true,
                true)
            .AddJsonFile($"{configurationsDirectory}/localization.json", false, true)
            .AddJsonFile($"{configurationsDirectory}/localization.{env.EnvironmentName}.json", true,
                true)
            .AddEnvironmentVariables();
        return builder;
    }
}