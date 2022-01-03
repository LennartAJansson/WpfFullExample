using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WpfWithWebApi.Wpf.Configuration;

namespace WpfWithWebApi.Wpf.Services
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddHttpClient("SecureHttpClient", ConfigureSecureHttpClientOptions);
            services.AddHttpClient("UnsecureHttpClient", ConfigureUnsecureHttpClientOptions);

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ICurrentUser, CurrentUser>();
            services.AddSingleton<ICurrentPerson, CurrentPerson>();
            services.AddTransient<IPeopleService, PeopleService>();

            return services;
        }

        private static void ConfigureUnsecureHttpClientOptions(IServiceProvider serviceProvider, HttpClient client)
        {
            //This should be used by the service that do the actual login, we still don't have any Token
            HttpClientSettings options = serviceProvider.GetService<IConfiguration>()
                .GetSection(HttpClientSettings.SectionName)
                .Get<HttpClientSettings>();

            client.BaseAddress = new Uri(options.Url);
        }

        private static void ConfigureSecureHttpClientOptions(IServiceProvider serviceProvider, HttpClient client)
        {
            //This should be used by all the services that do anything using the Token
            HttpClientSettings options = serviceProvider.GetService<IConfiguration>()
                .GetSection(HttpClientSettings.SectionName)
                .Get<HttpClientSettings>();

            ICurrentUser currentUser = serviceProvider.GetService<ICurrentUser>();

            client.BaseAddress = new Uri(options.Url);

            //https://stackoverflow.com/questions/30858890/how-to-use-httpclient-to-post-with-authentication
            byte[] byteArray = new UTF8Encoding().GetBytes($"{options.ClientId}:{options.ClientSecret}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }
}