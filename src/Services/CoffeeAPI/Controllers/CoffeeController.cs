using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace CoffeeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private static readonly string[] coffees = new[]
        {
            "Flat White", "Long Black", "Latte", "Americano", "Cappuccino"
        };

        private readonly ILogger _logger;


        public CoffeeController(ILogger logger)
        {
            _logger = logger.ForContext<CoffeeController>();

            _logger.Information("CoffeeController initialized.");
        }

        [HttpGet]
        public ActionResult Get()
        {
            _logger.Information("Get requested");
            var rng = new Random();

            return Ok(coffees[rng.Next(coffees.Length)]);
        }
    }
}
