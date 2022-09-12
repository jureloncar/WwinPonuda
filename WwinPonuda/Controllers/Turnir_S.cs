using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WwinPonuda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Turnir_S : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
