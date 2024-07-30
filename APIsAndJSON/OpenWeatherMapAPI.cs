using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        private HttpClient _client;
        private static string apiKey = "2d6ddb86014eda3ba435b286931ad234";
        static string city = "houston";
        static string state = "tx";
        static string country = "us";
        static string unit = "imperial";
        string weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city},{state},{country}&units={unit}&appid={apiKey}";

        public OpenWeatherMapAPI(HttpClient client)
        {
            _client = client;
        }

        public async Task getWeather()
        {
            HttpResponseMessage response = await _client.GetAsync(weatherURL);

            string result = await response.Content.ReadAsStringAsync();
            var data = JObject.Parse(result);

            string cityName = data["name"].ToString();
            string weather = data["weather"][0]["description"].ToString();
            double temp = Convert.ToDouble(data["main"]["temp"]);
            double feelsLike = Convert.ToDouble(data["main"]["feels_like"]);
            int humidity = Convert.ToInt32(data["main"]["humidity"]);
            double windSpeed = Convert.ToDouble(data["wind"]["speed"]);

            Console.WriteLine($"Current weather in {cityName}:");
            Console.WriteLine($"  - Weather: {weather}");
            Console.WriteLine($"  - Temperature: {temp}°F");
            Console.WriteLine($"  - Feels Like: {feelsLike}°F");
            Console.WriteLine($"  - Humidity: {humidity}%");
            Console.WriteLine($"  - Wind Speed: {windSpeed} mph");
        }
    }
}
