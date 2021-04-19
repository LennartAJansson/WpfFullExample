using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WpfApp2.Configurations
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, HostBuilderContext context)
        {
            services.Configure<WindowsInfo>(windowsInfo => context.Configuration.GetSection(WindowsInfo.SectionName).Bind(windowsInfo));

            return services;
        }
    }
}
