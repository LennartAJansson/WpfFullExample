using Microsoft.Extensions.DependencyInjection;

namespace WpfApp2.ViewModels
{
    public static class ViewModelExtensions
    {
        public static IServiceCollection AddApplicationViewModels(this IServiceCollection services)
        {
            services.AddTransient<MainViewModel>();
            return services;
        }
    }
}
