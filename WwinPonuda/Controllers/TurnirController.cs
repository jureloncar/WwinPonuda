using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http.Cors;
using WwinPonuda.Models;
using WwinPonuda.Repository;
using WwinPonuda.Repository.Interface;

namespace WwinPonuda.Controllers
{
    [EnableCors("*", "*", "*")]
    [Route("api/Turnirs")]
    [ApiController]
    public class TurnirsController : ControllerBase
    {
        private readonly ITurnirRepository _turnirRepo;
        private readonly object GetTurnirImage;

        public TurnirsController(ITurnirRepository turnirRepo) => _turnirRepo = turnirRepo;

        [HttpGet]
        public async Task<IActionResult> GetTurnirs()
        {
            var turnirs = await _turnirRepo.GetTurnirs();
            return Ok(turnirs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTurnirImage(TurnirImage turnirImage)
        {
            try
            {
                var createdTurnirImage = await _turnirRepo.CreateTurnirImage(turnirImage);
                return CreatedAtRoute("TurnirID", new { id = createdTurnirImage.ID }, createdTurnirImage);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
    