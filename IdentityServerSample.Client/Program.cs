using Newtonsoft.Json.Linq;
using System.Net.Http;
using IdentityModel.Client;
using System;

namespace IdentityServerSample.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DiscoveryResponse response = DiscoveryClient.GetAsync("http://localhost:5000").Result;
            var tokenClient = new TokenClient(response.TokenEndpoint, "client", "secret");
            TokenResponse tokenResponse = tokenClient.RequestClientCredentialsAsync("api1").Result;

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
            Console.WriteLine(tokenResponse.Json);
            Console.ReadKey();

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            HttpResponseMessage responseMessage = client.GetAsync("http://localhost:50001/api/identity").Result;

            if (!responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                Console.WriteLine(JArray.Parse(responseMessage.Content.ReadAsStringAsync().Result));
            }
        }
    }
}
