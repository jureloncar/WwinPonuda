using Dapper;
using WwinPonuda.Context;
using WwinPonuda.Models;
using WwinPonuda.Repository.Interface;

namespace WwinPonuda.Repository
{

    public class TurnirRepository : ITurnirRepository
    {
        private const string ORIGINAL_IMAGES_URL = @"C:\SportBook\png_";
        private const string NEW_IMAGES_URL = @"C:\SportBook1\png_";

        private readonly DapperContext _context;

        public TurnirRepository(DapperContext context)
        {
            _context = context;
        }

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

        public async Task<string?> CreateTurnirImage(int turnirId, string? imageUrl, string? size)
        {
            // 1. Korisnik na UI nađe sliku i klikne pošalji za neki određeni turnir
            // 2. U bazi podataka će se napraviti novi red u tablici TurnirImage koji će imati sljedeće podatke
            //    - TurnirID = IDTurnir od izabranog turnira
            //    - ImageUrl = url od slike koju je korisnik izabrao
            //    - StatusImageID = 1
            // 3. File koji je korisnik izabrao će se prebaciti u folder sa slikama za turnire i preimenovati u TurnirID.png
            var query = $"select top (1) * from Turnir_S where {nameof(Turnir.IDTurnir)} = {turnirId}";
            using (var connection = _context.CreateConnection())
            {
                var turnir = await connection.QueryFirstOrDefaultAsync<Turnir>(query);
                if (turnir == null || !File.Exists(imageUrl))
                {
                    return null;
                }

                var destinationDirectoryPath = $@"{NEW_IMAGES_URL}{size}";
                var destinationPath = $@"{destinationDirectoryPath}\{turnirId}.png";
                if (!Directory.Exists(destinationDirectoryPath))
                {
                    Directory.CreateDirectory(destinationDirectoryPath);
                }
                await connection.ExecuteAsync($"INSERT INTO TurnirImage (ID, {nameof(TurnirImage.TurnirID)}, {nameof(TurnirImage.StatusImageID)}, {nameof(TurnirImage.ImageUrl)}) VALUES ({turnirId}, {turnirId}, 1, '{destinationPath}')");
                
                File.Copy(imageUrl, destinationPath, true);

                return destinationPath;
            }
        }

        private string LoadImage(int id)
        {
            try
            {
                byte[] imageArray = File.ReadAllBytes($"{ORIGINAL_IMAGES_URL}\\{id}.png");
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                return $"data: image / png; base64, {base64ImageRepresentation}";
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
