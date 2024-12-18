﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherAPI
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }


        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; }


        [JsonPropertyName("main")]
        public MainWeather MainWheater { get; set; }


        [JsonPropertyName("base")]
        public string Base {  get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }


        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }


        [JsonPropertyName("dt")]
        public int Dt {  get; set; }


        [JsonPropertyName("sys")]
        public SysWeather SysWeather { get; set; }


        [JsonPropertyName("cod")]
        public int Cod {  get; set; }


    }
}
