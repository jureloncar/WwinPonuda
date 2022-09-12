using WwinPonuda.Context;
using WwinPonuda.Repository.Interface;

namespace WwinPonuda.Repository
{
    
        public class TurnirSRepository : ITurnirSRepository
        {
            private readonly DapperContext _context;
            public TurnirSRepository(DapperContext context) => _context = context;
        }
    }

