using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WpfWithWebApi.Wpf.Configuration
{
    public static class ApplicationConfigurationExtensions
    {
        public static IServiceCollection AddApplicationConfigurations(this IServiceCollection services, HostBuilderContext context)
        {
            services.Configure<HttpClientSettings>(clientSettings =>
                context.Configuration.GetSection(HttpClientSettings.SectionName).Bind(clientSettings));

            services.Configure<WindowsInfo>(windowsInfo =>
                context.Configuration.GetSection(WindowsInfo.SectionName).Bind(windowsInfo));

            return services;
        }
    }
}