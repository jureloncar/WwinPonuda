using WwinPonuda.Context;
using WwinPonuda.Contracts;

namespace WwinPonuda.Respository
{
    public class Turnir_SRespository
    {
        public class TurnirSRespository : ITurinir_SRespository
        {
            private readonly DapperContext _context;
            public TurnirSRespository(DapperContext context) => _context = context;
        }
    }
}
