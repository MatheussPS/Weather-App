using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Service;

namespace WeatherApp.ViewModels
{
    public partial class MainPageViewModel: ObservableObject
    {
        [ObservableProperty]
        public string city;

        [ObservableProperty]
        public string cImage;

        [ObservableProperty]
        public string cityName;

        [ObservableProperty]
        public string temperatura;

        [ObservableProperty]
        public string temperaturaMinima;

        [ObservableProperty]
        public string temperaturaMaxima;

        [ObservableProperty]
        public string descricao;

        [ObservableProperty]
        public string sensacao;

        [ObservableProperty]
        public string vento;

        [ObservableProperty]
        public string umidade;

        [ObservableProperty]
        public string pais;

        [ObservableProperty]
        public string coordenadas;

        [ObservableProperty]
        public string windVelocidade;

        public WeatherAPIService service = new WeatherAPIService();

        public ICommand GetWeatherCommand { get; set; }

            public MainPageViewModel()
            {
                GetWeatherCommand = new Command(async () => await GetWeather());

                SetInformacaoes();
            }

        public void SetInformacaoes()
        {
            CImage = "cloud.png";
            CityName = "Cidade";
            Temperatura = "Temperatura: 0°C";
            TemperaturaMinima = "Temperatura Mínima: 0°C";
            TemperaturaMaxima = "Temperatura Máxima: 0°C";
            Descricao = "Descrição: Nenhuma";
            Sensacao = "Sensação Térmica: 0°C";
            Vento = "Vento: 0 km/h";
            Umidade = "Umidade: 0%";
            Pais = "País: Desconhecido";
            Coordenadas = "Coordenadas: 0,0";
            WindVelocidade = "Velocidade do Vento: 0 km/h";
        }

        public async Task GetWeather()
        {
            
                Debug.WriteLine(city);
                WeatherAPI weatherAPI = await service.GetWeatherResponse(city);
            
                if (weatherAPI == null)
                {
                    SetInformacaoes();
                    CityName = $"{city} não encontrada";
                }
                else
                {
                    AtualizaInformacoes(weatherAPI);
                }
                
            
            
            
        }

        public void AtualizaInformacoes(WeatherAPI weatherAPI)
        {
            CImage = $"{weatherAPI.Weather[0].MainWeather}.png";

            CityName = $" {weatherAPI.Name},{weatherAPI.SysWeather.Country}";

            Temperatura = $"Temperatura:  {weatherAPI.MainWheater.Temp}°C";

            TemperaturaMinima = $"Temperatura Mínima:  {weatherAPI.MainWheater.TempMin}°C";

            TemperaturaMaxima = $"Temperatura Máxima:  {weatherAPI.MainWheater.TempMax}°C";

            Descricao = $"Descrição:  {weatherAPI.Weather[0].Description}";

            Sensacao = $"Sensação Térmica:  {weatherAPI.MainWheater.FeelsLike}°C";

            Vento = $"Vento:  {weatherAPI.Wind.Speed} km/h";

            Umidade = $"Umidade:  {weatherAPI.MainWheater.Humidity}%";

            Pais = $"País:  {weatherAPI.SysWeather.Country}";

            Coordenadas = $"Coordenadas:  {weatherAPI.Coord.Lat}, {weatherAPI.Coord.Lon}";

            WindVelocidade = $"Velocidade do Vento:  {weatherAPI.Wind.Speed} km/h";
        
        }


    }


}
