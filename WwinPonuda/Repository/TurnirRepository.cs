using Dapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Buffers.Text;
using System.ComponentModel;
using System.Data;
using System.Net.NetworkInformation;
using System.Web.Http.Results;
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

        async Task<IEnumerable<TurnirImage>> ITurnirRepository.CreateTurnirImage(TurnirImage turnirImage)
        {
            //uzeti sliku iz turnirImage.ImgUrl
            //prebaciti u novi folder i preimenovati u TurnirID.png
            var query = "select top (25) * from Turnir_S where Image NOT IN (Select ImageUrl FROM TurnirImage)";
            using (var connection = _context.CreateConnection())
            {
                var turnirs = await connection.QueryAsync<TurnirImage>(query);

                TurnirImage.StatusImageID = 1;

                await TurnirImage.Update(ImageUrl);

                var fileStream = new FileStream("SportBook2.jpg", FileMode.CreateNew);
                file.CopyTo(fileStream);

                string fileContents;
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContents = reader.ReadToEnd();
                }

                await query.Add(fileContents, TurnirImage.ID);


                //spremiti novi podataka sa statusom 1 u TrnirImages bazu



            }
        }

        private string URL_LOCATION = @"C:\SportBook\png_small";
        private object file;

        public object ImageUrl { get; private set; }

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
