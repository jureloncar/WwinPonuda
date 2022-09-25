using Dapper;
using System.Buffers.Text;
using System.Data;
using System.Net.NetworkInformation;
using WwinPonuda.Context;
using WwinPonuda.Models;
using WwinPonuda.Repository.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace WwinPonuda.Repository
{

    public class TurnirRepository : ITurnirRepository
    {
        private readonly DapperContext _context;
        public TurnirRepository(DapperContext context) => _context = context;

        public async Task<IEnumerable<Turnir>> GetTurnirs()
        {
            var query = "select top (25) * from Turnir_S where IDTurnir NOT IN (Select TurnirID FROM TurnirImage)";
            using (var connection = _context.CreateConnection())
            {
                var turnirs = await connection.QueryAsync<Turnir>(query);
                foreach (var item in turnirs)
                {
                    item.Image = LoadImage(item.IDTurnir);
                }
                return turnirs.ToList();
            }
        }

        Task<IEnumerable<TurnirImage>> ITurnirRepository.CreateTurnirImage(TurnirImage turnirImage)
        {
            //uzeti sliku iz turnirImage.ImgUrl
            //prebaciti u novi folder i preimenovati u TurnirID.png



            //spremiti novi podataka sa statusom 1 u TrnirImages bazu


            throw new NotImplementedException();
        }

        private string URL_LOCATION = @"C:\SportBook\png_small";
        private string LoadImage(int id)
        {
            try
            {
                byte[] imageArray = System.IO.File.ReadAllBytes($"{URL_LOCATION}\\{id}.png");
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                return $"data: image / png; base64, {base64ImageRepresentation}";
            }
            catch (Exception)
            {

                return String.Empty;
            }
     
        }
    }
}
