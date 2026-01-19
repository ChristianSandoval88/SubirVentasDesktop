namespace SubirVentas.Models
{
    public class PRODUCTS : IEquatable<PRODUCTS>
    {
        public string? ID { get; set; }
        public string? REFERENCE { get; set; }
        public string? CODE { get; set; }
        public string? NAME { get; set; }
        public decimal? PRICEBUY { get; set; }
        public decimal? PRICESELL { get; set; }
        /*public decimal? PRICESELL1 { get; set; }
        public decimal? PRICESELL2 { get; set; }
        public decimal? PRICESELL3 { get; set; }
        public decimal? PRICESELL4 { get; set; }*/
        public string? CATEGORY { get; set; }
        public string? TAXCAT { get; set; }
        public bool Equals(PRODUCTS other)
        {
            if (other is null)
                return false;

            return this.ID == other.ID;
        }

        public override bool Equals(object obj) => Equals(obj as PRODUCTS);
        public override int GetHashCode() => ID?.GetHashCode() ?? 0;
    }
}
