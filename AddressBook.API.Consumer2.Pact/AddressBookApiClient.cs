using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace APIConsumerPact
{
    public class Profile
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class AddressBookApiClient
    {
        private readonly HttpClient _client;

        public AddressBookApiClient(string baseUri = null)
        {
            _client = new HttpClient {BaseAddress = new Uri(baseUri ?? "https://localhost:5001")};
        }

        public Profile GetProfileById(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/profiles/{id}");
            request.Headers.Add("Accept", "application/json");

            var response = _client.SendAsync(request);

            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            var reasonPhrase = response.Result
                .ReasonPhrase;

            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.OK)
            {
                return !string.IsNullOrEmpty(content)
                    ? JsonConvert.DeserializeObject<Profile>(content)
                    : null;
            }

            throw new Exception(reasonPhrase);
        }
    }
}