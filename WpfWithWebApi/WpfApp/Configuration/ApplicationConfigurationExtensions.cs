using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WpfWithWebApi.Wpf.Configuration
{
    public static class ApplicationConfigurationExtensions
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, HostBuilderContext hostBuilder)
        {
            //To get an instance of a specific setting using ConfigurationBinder:
            //var setting = hostBuilder.Configuration.GetSection(CmdGroup.Section).Get<CmdGroup>();

            services.Configure<SampleConfigData>(settings =>
                hostBuilder.Configuration.GetSection(SampleConfigData.Section).Bind(settings));

            services.Configure<HttpSettings>(settings =>
                hostBuilder.Configuration.GetSection(HttpSettings.Section).Bind(settings));

            return services;
        }
    }
}