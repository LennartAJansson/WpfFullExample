using Microsoft.Extensions.DependencyInjection;

namespace WpfApp2.Views
{
    public static class ViewExtensions
    {
        public static IServiceCollection AddApplicationViews(this IServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            return services;
        }
    }
}
