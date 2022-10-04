using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Congelando", "Frio", "Suave", "Quente", "Escaldante"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        Random rng = new Random();

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            IEnumerable<WeatherForecast> weathers =  Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-22, 55),
                
            })
            .ToArray();

            foreach(WeatherForecast weather in weathers)
            {
                if (weather.TemperatureC <= -2) weather.Summary = Summaries[0];
                else if (weather.TemperatureC >= -1 && weather.TemperatureC <= 16) weather.Summary = Summaries[1];
                else if (weather.TemperatureC >= 17 && weather.TemperatureC <= 26) weather.Summary = Summaries[2];
                else if (weather.TemperatureC >= 27 && weather.TemperatureC <= 38) weather.Summary = Summaries[3];
                else if (weather.TemperatureC >= 39) weather.Summary = Summaries[4];
            }

            return weathers;
        }
    }
}
