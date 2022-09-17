using Dapper;
using WwinPonuda.Context;
using WwinPonuda.Models;
using WwinPonuda.Repository.Interface;

namespace WwinPonuda.Repository
{

    public class TurnirRepository : ITurnirRepository
    {
        private readonly DapperContext _context;
        public TurnirRepository(DapperContext context) => _context = context;

        public Task<Turnir> GetTurnir(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Turnir>> GetTurnirs()
        {
            var query = "SELECT * FROM Turnir_S";
            using (var connection = _context.CreateConnection())
            {
                var Turnirs = await connection.QueryAsync<Turnir>(query);
                return Turnirs.ToList();
            }
        }

        public async Task<Turnir> GetTurnirs(int id)
        {
            var query = "SELECT * FROM Turnir_S WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var turnir = await connection.QuerySingleOrDefaultAsync<Turnir>(query, new { id });
                return turnir;
            }
        }
    }
}

