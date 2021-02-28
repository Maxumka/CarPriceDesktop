using CarPriceDesktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CarPriceDesktop.Services
{
    internal sealed class CarPriceService
    {
        private readonly HttpClient _client;

        private static readonly Lazy<CarPriceService> userService = new(() => new CarPriceService());

        private CarPriceService()
        {
            _client = new();
            _client.BaseAddress = new("https://localhost:44354/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new("application/json"));
        }

        public static CarPriceService CreateCarPriceService() => userService.Value;

        public string Token { get; set; } = "Guest";

        public async Task GetTokenAsync(UserModel user)
        {
            var response = await _client.PostAsJsonAsync("/token", user);

            if (response.IsSuccessStatusCode)
            {
                var resultResponse = await response.Content.ReadAsStringAsync();

                Token = JsonConvert.DeserializeObject<string>(resultResponse);

                _client.DefaultRequestHeaders.Authorization = new("Bearer", Token);
            }
        }

        public async Task SignUpUserAsync(UserModel user)
        {
            var response = await _client.PostAsJsonAsync("users", user);
            response.EnsureSuccessStatusCode();
        }

        public async Task<int> CalculatePriceAsync(CarModel carModel)
        {
            var price = 0;

            var response = await _client.PostAsJsonAsync("calculate", carModel);

            if (response.IsSuccessStatusCode)
            {
                var jsonPrice = await response.Content.ReadAsStringAsync();

                price = JsonConvert.DeserializeObject<int>(jsonPrice);
            }

            return price;
        }

        public async Task<IEnumerable<CarModel>> GetHistoryAsync()
        {
            IEnumerable<CarModel> cars = null;

            var response = await _client.GetAsync("history");

            if (response.IsSuccessStatusCode)
            {
                var jsonCars = await response.Content.ReadAsStringAsync();

                cars = JsonConvert.DeserializeObject<IEnumerable<CarModel>>(jsonCars);
            }

            return cars;
        }
    }
}
