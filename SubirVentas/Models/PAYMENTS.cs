namespace SubirVentas.Models
{
    public class PAYMENTS : IEquatable<PAYMENTS>
    {
        public string? ID { get; set; }
        public string? RECEIPT { get; set; }
        public string? PAYMENT { get; set; }
        public decimal? TOTAL { get; set; }
        public string? NOTES { get; set; }
        public bool Equals(PAYMENTS other)
        {
            if (other is null)
                return false;

            return this.ID == other.ID;
        }

        public override bool Equals(object obj) => Equals(obj as PAYMENTS);
        public override int GetHashCode() => (ID).GetHashCode();
    }
}
