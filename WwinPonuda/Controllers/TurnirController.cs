using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WwinPonuda.Repository.Interface;

namespace WwinPonuda.Controllers
{
    [Route("api/Turnirs")]
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

        [HttpGet("{id}", Name = "IDTurnir")]
        public async Task<IActionResult> GetTurnir(int id)
        {
            var turnir = await _turnirRepo.GetTurnir(id);
            if (turnir == null)
                return NotFound();
            return Ok(turnir);
        }
    }
}
