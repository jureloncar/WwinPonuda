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
        public string? MinParova { get; set; }
        public string? MaxParova { get; set; }
        public string? MaxUlog { get; set; }
        public string? SastavniTurnir { get; set; }
        public int TurnirIDSastavni { get; set; }
        public DateTime Sink { get; set; }
        public string? Aktivan { get; set; }
        public string? RedniBrojIspis { get; set; }
        public string? RedniBrojFavorit { get; set; }
        public string? TjednaPonuda { get; set; }
        public int GrupaOkladaID { get; set; }
        public string? TournamentName { get; set; }
        public int BetSourceID { get; set; }
        public int SourceTournamentID { get; set; }
        public DateTime TimeStampUTC { get; set; }
        public string? PrevodNapomena { get; set; }
    }
}
