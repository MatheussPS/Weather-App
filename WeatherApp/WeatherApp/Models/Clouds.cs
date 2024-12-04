using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class Clouds
    {
        [JsonPropertyName("clouds")]
        public int All {  get; set; }
    }
}
