using Microsoft.AspNetCore.Mvc;

namespace WwinPonuda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private string URL_LOCATION = @"C:\SportBook\";

        [HttpGet]
        public async Task<List<string>> GetImages(string size)
        {
            switch (size)
            {
                case "big":
                    URL_LOCATION += "png_big";
                    break;
                case "medium":
                    URL_LOCATION += "png_medium";
                    break;
                case "small":
                    URL_LOCATION += "png_small";
                    break;
                default:
                    URL_LOCATION += "png_small";
                    break;
            }

            return Directory.GetFiles(URL_LOCATION, "*.*", SearchOption.AllDirectories)
                .Take(10).ToList();
        }
    }
}
