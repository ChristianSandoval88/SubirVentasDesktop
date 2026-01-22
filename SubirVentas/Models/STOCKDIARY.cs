namespace SubirVentas.Models
{
    public class STOCKDIARY : IEquatable<STOCKDIARY>
    {
        public string? ID { get; set; }
        public DateTime? DATENEW { get; set; }
        public int? REASON { get; set; }
        public string? LOCATION { get; set; }
        public string? PRODUCT { get; set; }
        public decimal? UNITS { get; set; }
        public decimal? PRICE { get; set; }
        public bool Equals(STOCKDIARY other)
        {
            if (other is null)
                return false;

            return this.ID == other.ID;
        }

        public override bool Equals(object obj) => Equals(obj as STOCKDIARY);
        public override int GetHashCode() => ID?.GetHashCode() ?? 0;
    }
}
