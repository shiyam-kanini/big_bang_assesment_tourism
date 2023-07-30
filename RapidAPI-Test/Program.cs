using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RapidAPI_Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GetData();
        }
        public static async void GetData()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://real-time-pnr-status-api-for-indian-railways.p.rapidapi.com/indianrail/6217743114"),
                    Headers =
            {
                { "X-RapidAPI-Key", "9d0e43f983msh8dd924a5ad29eb7p1ed557jsn28ff53e57553" },
                { "X-RapidAPI-Host", "real-time-pnr-status-api-for-indian-railways.p.rapidapi.com" },
            },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
