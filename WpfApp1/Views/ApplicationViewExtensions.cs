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
            return services;
        }
    }
}