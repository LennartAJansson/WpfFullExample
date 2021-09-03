using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Net.Http;

using WpfWithWebApi.Wpf.Configuration;

namespace WpfWithWebApi.Wpf.Services
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddHttpClient<IPersonService, PersonService>(ConfigureClient);

            return services;
        }

        private static void ConfigureClient(IServiceProvider provider, HttpClient client)
        {
            HttpSettings options = provider.GetService<IConfiguration>()
                                .GetSection(HttpSettings.Section)
                                .Get<HttpSettings>();

            client.BaseAddress = new Uri(options.Url);
        }
    }
}