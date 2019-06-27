using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherTestXam.Models;

namespace WeatherTestXam
{
    public class Core
    {
        public static async Task<CityWeather> GetWeather(string cityName)
        {
            
            string key = "b7f10a8868ba2c83b0b49eff391c7f04";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q="
                + cityName + "&APPID=" + key + "&units=metric";

            //Make sure developers running this sample replaced the API key
            if (key == "YOUR API KEY HERE")
            {
                throw new ArgumentException("You must obtain an API key from openweathermap.org/appid and save it in the 'key' variable.");
            }

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                CityWeather weather = new CityWeather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " C";
                weather.Wind = (string)results["wind"]["speed"]
                    + " mph Direction: " + DegreesToCardinal((double)results["wind"]["deg"]);
                return weather;
            }
            else
            {
                return null;
            }
        }

        // Direction of the wind function 
        public static string DegreesToCardinal(double degrees)
        {
            string[] caridnals = { "N", "NE", "E", "SE", "S", "SW", "W", "NW", "N" };
            return caridnals[(int)Math.Round(((double)degrees % 360) / 45)];
        }
    }
}
