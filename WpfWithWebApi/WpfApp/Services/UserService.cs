using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using WpfWithWebApi.Model;

namespace WpfWithWebApi.Wpf.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> logger;
        private readonly IHttpClientFactory httpClientFactory;

        public UserService(ILogger<UserService> logger, IHttpClientFactory httpClientFactory)
        {
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
        }

        public Task<User> LoginAsync(User user)
        {
            //We still haven't got any Token so use a UnsecureHttpClient
            HttpClient client = httpClientFactory.CreateClient("UnsecureHttpClient");
            //Get the token by sending the login and set IsValid based on outcome
            return Task.FromResult(user);
        }

        public Task<User> LogoutAsync(User user)
        {
            HttpClient client = httpClientFactory.CreateClient("SecureHttpClient");
            //Invalidate the token in user and set IsValid to false
            return Task.FromResult(user);
        }

        public Task<User> ChangePasswordAsync(User user, string newPassword)
        {
            HttpClient client = httpClientFactory.CreateClient("SecureHttpClient");
            //Get a new token by sending the password change
            return Task.FromResult(user);
        }

        public Task<User> RefreshAsync(User user)
        {
            HttpClient client = httpClientFactory.CreateClient("SecureHttpClient");
            //Update the token in user
            return Task.FromResult(user);
        }
    }
}

