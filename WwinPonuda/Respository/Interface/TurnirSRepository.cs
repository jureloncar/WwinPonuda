using WwinPonuda.Context;

namespace WwinPonuda.Respository.Interface
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
