using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using WpfWithWebApi.Model;
using WpfWithWebApi.Wpf.Extensions;

namespace WpfWithWebApi.Wpf.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly ILogger<PeopleService> logger;
        private readonly IHttpClientFactory httpClientFactory;

        public PeopleService(ILogger<PeopleService> logger, IHttpClientFactory httpClientFactory)
        {
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            HttpClient client = httpClientFactory.CreateClient("UnsecureHttpClient");
            string path = "people";
            HttpRequestMessage request = new(HttpMethod.Get, $"{client.BaseAddress}{path}");
            logger.LogHttpRequest(LogLevel.Information, request, "Request to web api");

            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            logger.LogHttpResponse(LogLevel.Information, response, "Response from web api");

            string json = await response.Content.ReadAsStringAsync();
            logger.LogInformation("Response json: {json}", json);

            IEnumerable<Person> peopleResponse = JsonSerializer.Deserialize<IEnumerable<Person>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return peopleResponse;
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            HttpClient client = httpClientFactory.CreateClient("UnsecureHttpClient");
            string path = $"people/{id}";
            HttpRequestMessage request = new(HttpMethod.Get, $"{client.BaseAddress}{path}");
            logger.LogHttpRequest(LogLevel.Information, request, "Request to web api");

            HttpResponseMessage response = await client.GetAsync(path).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            logger.LogHttpResponse(LogLevel.Information, response, "Response from web api");

            string json = await response.Content.ReadAsStringAsync();
            logger.LogInformation("Response json: {json}", json);

            Person personResponse = JsonSerializer.Deserialize<Person>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return personResponse;
        }
    }
}
