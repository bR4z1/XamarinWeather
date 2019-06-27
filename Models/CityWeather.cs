using System;
using System.Collections.Generic;
using System.Text;


namespace WeatherTestXam.Models
{
    public class CityWeather
    {
        // file название c именем города
        public string Filename { get; set; }
        // имя города
        public string Title { get; set; }
        public string Temperature { get; set; }
        public IList<object> Wind { get; set; }
    }
}
