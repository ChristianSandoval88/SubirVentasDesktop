namespace SubirVentas.Models
{
    public class CUSTOMERS : IEquatable<CUSTOMERS>
    {
        public string? ID { get; set; }
        public string? SEARCHKEY { get; set; }
        public string? TAXID { get; set; }
        public string? NAME { get; set; }
        public string? TAXCATEGORY { get; set; }
        public string? CARD { get; set; }
        public decimal? MAXDEBT { get; set; }
        public string? ADDRESS { get; set; }
        public string? ADDRESS2 { get; set; }
        public string? POSTAL { get; set; }
        public string? CITY { get; set; }
        public string? REGION { get; set; }
        public string? COUNTRY { get; set; }
        public string? FIRSTNAME { get; set; }
        public string? LASTNAME { get; set; }
        public string? EMAIL { get; set; }
        public string? PHONE { get; set; }
        public string? PHONE2 { get; set; }
        public string? FAX { get; set; }
        public string? NOTES { get; set; }
        public bool VISIBLE { get; set; }
        public DateTime? CURDATE { get; set; }
        public double? CURDEBT { get; set; }
        public bool Equals(CUSTOMERS other)
        {
            if (other is null)
                return false;

            return this.ID == other.ID;
        }

        public override bool Equals(object obj) => Equals(obj as CUSTOMERS);
        public override int GetHashCode() => (ID).GetHashCode();
    }
}
