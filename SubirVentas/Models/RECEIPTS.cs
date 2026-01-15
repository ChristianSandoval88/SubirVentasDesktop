namespace SubirVentas.Models
{
    public class RECEIPTS : IEquatable<RECEIPTS>
    {
        public string? ID { get; set; }
        public string? MONEY { get; set; }
        public DateTime? DATENEW { get; set; }
        public bool Equals(RECEIPTS other)
        {
            if (other is null)
                return false;

            return this.ID == other.ID;
        }

        public override bool Equals(object obj) => Equals(obj as RECEIPTS);
        public override int GetHashCode() => ID?.GetHashCode() ?? 0;
    }
}
