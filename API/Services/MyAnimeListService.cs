using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class MyAnimeListService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public MyAnimeListService(HttpClient httpClient, IConfiguration config) {
            _httpClient = httpClient;
            _config = config;

            Console.WriteLine("Using Client ID: " + _config["MAL:ClientId"]);

            //Setting up base URL and headers
            _httpClient.BaseAddress = new Uri("https://api.myanimelist.net/v2/");
            _httpClient.DefaultRequestHeaders.Add("X-MAL-CLIENT-ID", _config["MAL:ClientId"]);
        }

        public async Task<string?> GetTopAnimeAsync()
        {
            var response = await _httpClient.GetAsync("anime/ranking?ranking_type=all&limit=1");

            Console.WriteLine("Status Code: " + response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Body: " + body);

            if (!response.IsSuccessStatusCode)
                return null;

            return body;
        }

        public async Task<string?> SearchAnimeAsync(string query)
        {
            var response = await _httpClient.GetAsync($"anime?q={Uri.EscapeDataString(query)}&limit=5");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string?> GetAnimeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"anime/{id}?fields=id,title,main_picture,synopsis");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadAsStringAsync();
        }
    }
}