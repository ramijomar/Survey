namespace Survey.Questionnaire.Api.Common
{
    public static class ConfigurationFilesLoader
    {
        public static IConfigurationBuilder LoadConfigurationFiles(this IConfigurationBuilder builder, IWebHostEnvironment environment)
        {
            builder.AddJsonFile($@"{environment.ContentRootPath}ConfigurationFiles\connectionStrings\connectionStrings.json",
                optional: false,
                reloadOnChange: true);

            return builder;
        }
    }
}
