using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http.Cors;
using WwinPonuda.Models;
using WwinPonuda.Repository;
using WwinPonuda.Repository.Interface;

namespace WwinPonuda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnirsController : ControllerBase
    {
        private readonly ITurnirRepository _turnirRepo;

        public TurnirsController(ITurnirRepository turnirRepo) => _turnirRepo = turnirRepo;

        [HttpGet]
        public async Task<IActionResult> GetTurnirs()
        {
            var turnirs = await _turnirRepo.GetTurnirs();
            return Ok(turnirs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTurnirImage([FromBody]TurnirImageRequest turnirImageRequest)
        {
            try
            {
                var createdTurnirImageUrl = await _turnirRepo.CreateTurnirImage(turnirImageRequest.TurnirID, turnirImageRequest.ImageURL, turnirImageRequest.Size);
                if (createdTurnirImageUrl == null)
                {
                    return NotFound();
                }

                return Ok(createdTurnirImageUrl);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}

    