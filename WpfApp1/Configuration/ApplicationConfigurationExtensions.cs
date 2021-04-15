using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WpfApp1.Configuration
{
    public static class ApplicationConfigurationExtensions
    {
        public static IServiceCollection AddApplicationConfigurations(this IServiceCollection services, HostBuilderContext context)
        {
            services.Configure<WindowsInfo>(windowsInfo =>
                context.Configuration.GetSection(WindowsInfo.SectionName).Bind(windowsInfo));

            return services;
        }
    }
}