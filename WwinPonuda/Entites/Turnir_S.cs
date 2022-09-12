namespace WwinPonuda.Models
{
    public class Turnir_S
    {
        public int IDTurnir { get; set; }
        public int SportID { get; set; }
        public int KategorijaID { get; set; }
        public int SuperTurnirID { get; set; }
        public int BetradarTournamentID { get; set; }
        public int BRSuperTournamentID { get; set; }
        public byte? MinParova { get; set; }
        public byte? MaxParova { get; set; }
        public decimal? MaxUlog { get; set; }
        public byte? SastavniTurnir { get; set; }
        public int TurnirIDSastavni { get; set; }
        public DateTime Sink { get; set; }
        public byte? Aktivan { get; set; }
        public string? RedniBrojIspis { get; set; }
        public string? RedniBrojFavorit { get; set; }
        public string? TjednaPonuda { get; set; }
        public int GrupaOkladaID { get; set; }
        public string? TournamentName { get; set; }
        public byte? BetSourceID { get; set; }
        public int SourceTournamentID { get; set; }
        public DateTime TimeStampUTC { get; set; }
        public string? PrevodNapomena { get; set; }
    }
}
