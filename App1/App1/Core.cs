using System;
using System.Threading.Tasks;

namespace App1
{
    public class Core
    {
        public static async Task<Clima> GetWeather(string zipCode)
        {
            //Sign up for a free API key at http://openweathermap.org/appid
            string key = "7850d35fab652245646bbe51d9a2a08f";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
                + zipCode + "&appid=" + key;

            var results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Clima clima = new Clima();
                clima.Title = (string)results["name"];
                clima.Temperature = (string)results["main"]["temp"] + " F";
                clima.Wind = (string)results["wind"]["speed"] + " mph";
                clima.Humidity = (string)results["main"]["humidity"] + " %";
                clima.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                clima.Sunrise = sunrise.ToString() + " UTC";
                clima.Sunset = sunset.ToString() + " UTC";
                return clima;
            }
            else
            {
                return null;
            }
        }
    }
}