using Microsoft.Extensions.DependencyInjection;

namespace WpfApp1.Views
{
    public static class ApplicationViewExtensions
    {
        public static IServiceCollection AddApplicationViews(this IServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<PeopleView>();
            services.AddTransient<PersonView>();
            services.AddTransient<GraphView>();
            //Do not add those who should use a parent viewmodel from others, ToolBars, StatusBar
            return services;
        }
    }
}