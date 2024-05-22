using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;

namespace TelegramBackgroundService.Bot.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly TelegramBotClient client;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TelegramBotClient client)
        {
            this.client = client;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public async Task<IActionResult> Qales(CancellationToken cancellationToken)
        {
            await client.SendTextMessageAsync(
                chatId: 1633746526,
                text: "Working",
                cancellationToken: cancellationToken
            );

            return Ok("O'xshadi");
        }
    }
}
