using WwinPonuda.Models;

namespace WwinPonuda.Repository.Interface
{
    public interface ITurnirRepository
    {
        public Task<IEnumerable<Turnir>> GetTurnirs();
        public Task<IEnumerable<TurnirImage>> CreateTurnirImage(TurnirImage turnirImage);
    }
}
