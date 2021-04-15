
using Microsoft.Extensions.DependencyInjection;

namespace WpfWithWebApi.Wpf.ViewModels
{
    public static class ApplicationViewModelExtensions
    {
        public static IServiceCollection AddApplicationViewModels(this IServiceCollection services)
        {
            services.AddTransient<MainViewModel>();

            return services;
        }
    }
}