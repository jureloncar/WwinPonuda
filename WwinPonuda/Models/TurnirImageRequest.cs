using System.ComponentModel.DataAnnotations;

namespace WwinPonuda.Models
{
    public class TurnirImageRequest
    {
        [Range(0, int.MaxValue)]
        public int TurnirID { get; set; }

        [Required]
        public string? ImageURL { get; set; }

        public string? Size { get; set; } = "small";
    }
}
