using Microsoft.Extensions.DependencyInjection;

namespace WpfApp1.Services
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ICurrentPerson, CurrentPerson>();
            services.AddTransient<IPeopleService, PeopleService>();

            return services;
        }
    }
}