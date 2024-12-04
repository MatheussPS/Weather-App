using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class Coord
    {
        [JsonPropertyName("lon")]
        public double Lon { get;set; }

        [JsonPropertyName("lat")]
        public double lat { get; set; }
    }
}
