using Microsoft.Extensions.DependencyInjection;

namespace WpfApp1.ViewModels
{
    public static class ApplicationViewModelExtensions
    {
        public static IServiceCollection AddApplicationViewModels(this IServiceCollection services)
        {
            services.AddTransient<MainViewModel>();
            services.AddTransient<PeopleViewModel>();
            services.AddTransient<PersonViewModel>();
            services.AddTransient<GraphViewModel>();
            services.AddTransient<UserViewModel>();
            return services;
        }
    }
}