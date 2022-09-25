using Dapper;
using System.Data;
using WwinPonuda.Context;
using WwinPonuda.Models;
using WwinPonuda.Repository.Interface;

namespace WwinPonuda.Repository
{

    public class TurnirRepository : ITurnirRepository
    {
        private readonly DapperContext _context;
        public TurnirRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<Turnir>> GetTurnirs()
        {
            var query = "select top (15) * from Turnir_S where IDTurnir NOT IN (Select TurnirID FROM TurnirImage)";
            using (var connection = _context.CreateConnection())
            {
                var Turnirs = await connection.QueryAsync<Turnir>(query);
                return Turnirs.ToList();
            }
        }

        Task<IEnumerable<TurnirImage>> ITurnirRepository.CreateTurnirImage(TurnirImage turnirImage)
        {
            throw new NotImplementedException();
        }
    }
}
