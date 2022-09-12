using WwinPonuda.Context;
using WwinPonuda.Respository.Interface;

namespace WwinPonuda.Respository
{
    public class TurnirSRepository
    {
        public class TurnirSRespository : ITurnirSRepository
        {
            private readonly DapperContext _context;
            public TurnirSRespository(DapperContext context) => _context = context;
        }
    }
}
