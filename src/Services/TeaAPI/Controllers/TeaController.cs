using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeaController : ControllerBase
    {
        private static readonly string[] teas = new[]
        {
            "Earl greay", "English breakfast", "Green", "Peppermint", "Camomile"
        };

        [HttpGet]
        public ActionResult Get()
        {
            var rnd = new Random();

            return Ok(teas[rnd.Next(teas.Length)]);
        }
    }
}
