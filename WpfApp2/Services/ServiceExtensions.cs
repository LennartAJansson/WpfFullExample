using Microsoft.Extensions.DependencyInjection;

namespace WpfApp2.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
