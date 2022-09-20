using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
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
        public TurnirsController(ITurnirRepository turnirRepo) => _turnirRepo = turnirRepo;

        [HttpGet]
        public async Task<IActionResult> GetTurnirs()
        {
            var turnirs = await _turnirRepo.GetTurnirs();
            return Ok(turnirs);
        }

        [HttpPatch("{id}")]
        public async Task AddImage(string id, IFormatFile file)
        {
            var Turnir = await ITurnirRepository.GetByIDTurnir();
            Turnir.StatusImage = 1;

            await ITurnirRepository.update(Turnir);

            var fileStream = new FileStream("tempFile.jpg", FileMode.CreateNew);
            file.CopyTo(fileStream);

            string fileContents;
            using (StreamReader reader = new StreamReader(fileStream))
            {
                fileContents = reader.ReadToEnd();
            }
            await TurnirImageRepository.Add(fileContents, Turnir.Id);
        }
    }