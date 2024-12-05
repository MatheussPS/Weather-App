using System.Diagnostics;
using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Service
{
    public class WeatherAPIService
    {
        private HttpClient httpClient;
        private WeatherAPI weatherAPI;
        private JsonSerializerOptions jsonSerializerOptions;
        Uri uri = new Uri("http://api.openweathermap.org/data/2.5/weather?appid=");
        public string key = "8e68d299c4142af4b78cf79c7d7ca3ce";
        public string options = "lang=pt_br&units=metric";

        public WeatherAPIService() { 
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<WeatherAPI> GetWeatherResponse(string cityName)
        {
            try
            {
                string requestUrl = $"{uri}{key}&q={cityName}&{options}";
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
         
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    weatherAPI = JsonSerializer.Deserialize<WeatherAPI>(content, jsonSerializerOptions);
                }
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
            }

            return weatherAPI;
        }
    }
}
