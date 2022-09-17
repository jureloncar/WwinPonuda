using WwinPonuda.Models;

namespace WwinPonuda.Repository.Interface
{
    public interface ITurnirRepository
    {
        public Task<IEnumerable<Turnir>> GetTurnirs();
        public Task<Turnir> GetTurnir(int id);

    }
}
