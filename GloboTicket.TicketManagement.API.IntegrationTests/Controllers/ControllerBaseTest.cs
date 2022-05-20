using GloboTicket.TicketManagement.API.IntegrationTests.Base;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GloboTicket.TicketManagement.API.IntegrationTests.Controllers
{
    [Collection(nameof(IntegrationTestServerCollectionFixture))]
    public class ControllerBaseTest : IDisposable
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private readonly string _baseControllerRoute;

        protected ControllerBaseTest(CustomWebApplicationFactory<Program> factory, string baseControllerRoute)
        {
            _baseControllerRoute = baseControllerRoute;
            _factory = factory;
            _client = factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });
        }

        protected StringContent GetHttpStringContent(object data)
        {
            return new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        }

        protected Task<HttpResponseMessage> SendPostRequest(object request, string route = "")
        {
            return GetClient().PostAsync($"{_baseControllerRoute}{route}", GetHttpStringContent(request));
        }

        protected Task<HttpResponseMessage> SendPostRequestWithForm(HttpContent request, string route = "")
        {
            return GetClient().PostAsync($"{_baseControllerRoute}{route}", request);
        }

        protected Task<HttpResponseMessage> SendGetRequest(string route = "")
        {
            return GetClient().GetAsync($"{_baseControllerRoute}{route}");
        }

        protected Task<HttpResponseMessage> SendUpdateRequest(object request, string route = "")
        {
            return GetClient().PutAsync($"{_baseControllerRoute}{route}", GetHttpStringContent(request));
        }

        protected Task<HttpResponseMessage> SendDeleteRequest(string route = "")
        {
            return GetClient().DeleteAsync($"{_baseControllerRoute}/{route}");
        }

        protected static async Task<List<U>> GetResponseResults<U>(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<U>>(responseString);
        }

        protected static async Task<U> GetResponseResult<U>(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<U>(responseString);
        }

        public void Dispose()
        {
            _factory?.Dispose();
            _client.Dispose();
            GC.SuppressFinalize(this);
        }

        private HttpClient GetClient()
        {
            _client.DefaultRequestHeaders.Remove("Authorization");
            _client.DefaultRequestHeaders.Remove("If-Version");
            return _client;
        }
    }
}
