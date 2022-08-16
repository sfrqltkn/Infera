namespace Infera_WebApi.Configuration
{
    static class CustomConfig
    {
        public static IConfiguration AppSetting { get; }

        static CustomConfig()
        {
            AppSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
