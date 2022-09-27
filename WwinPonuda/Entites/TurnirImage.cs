namespace WwinPonuda.Models
{
    public class TurnirImage
    {
        public static int StatusImageID { get; internal set; }
        public int TurnirID { get; set; }
        public string ImageUrl { get; set; }

        internal static Task Update(object imageUrl)
        {
            throw new NotImplementedException();
        }
    }
}

