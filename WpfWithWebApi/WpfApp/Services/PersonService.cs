using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using WpfWithWebApi.Model;
using WpfWithWebApi.Wpf.Extensions;

namespace WpfWithWebApi.Wpf.Services
{
    public class PersonService : IPersonService
    {
        private readonly ILogger<PersonService> logger;
        private readonly IHttpClientFactory httpClientFactory;

        public PersonService(ILogger<PersonService> logger, IHttpClientFactory httpClientFactory)
        {
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            HttpClient client = httpClientFactory.CreateClient("UnsecureHttpClient");

            HttpRequestMessage request = new();
            logger.LogHttpRequest(LogLevel.Information, request, "Request to web api");

            HttpResponseMessage response = await client.GetAsync("/person").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            logger.LogHttpResponse(LogLevel.Information, response, "Response from web api");

            string json = await response.Content.ReadAsStringAsync();
            logger.LogInformation("Response json: {json}", json);

            return JsonSerializer.Deserialize<IEnumerable<Person>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Person> GetPersonAsync(object id)
        {
            HttpClient client = httpClientFactory.CreateClient("UnsecureHttpClient");

            HttpRequestMessage request = new();
            logger.LogHttpRequest(LogLevel.Information, request, "Request to web api");

            HttpResponseMessage response = await client.GetAsync($"/person/{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            logger.LogHttpResponse(LogLevel.Information, response, "Response from web api");

            string json = await response.Content.ReadAsStringAsync();
            logger.LogInformation("Response json: {json}", json);

            return JsonSerializer.Deserialize<Person>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}