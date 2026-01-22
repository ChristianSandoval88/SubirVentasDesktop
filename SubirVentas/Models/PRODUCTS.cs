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
        #region precios
        public decimal? PRICESELL1 { get; set; }
        public decimal? PRICESELL2 { get; set; }
        public decimal? PRICESELL3 { get; set; }
        public decimal? PRICESELL4 { get; set; }
        public decimal? PRICESELL5 { get; set; }
        public decimal? PRICESELL6 { get; set; }
        public decimal? PRICESELL7 { get; set; }
        public decimal? PRICESELL8 { get; set; }
        public decimal? PRICESELL9 { get; set; }
        public decimal? PRICESELL10 { get; set; }
        public decimal? PRICESELL11 { get; set; }
        public decimal? PRICESELL12 { get; set; }
        public decimal? PRICESELL13 { get; set; }
        public decimal? PRICESELL14 { get; set; }
        public decimal? PRICESELL15 { get; set; }
        public decimal? PRICESELL16 { get; set; }
        public decimal? PRICESELL17 { get; set; }
        public decimal? PRICESELL18 { get; set; }
        public decimal? PRICESELL19 { get; set; }
        public decimal? PRICESELL20 { get; set; }
        public decimal? PRICESELL21 { get; set; }
        public decimal? PRICESELL22 { get; set; }
        public decimal? PRICESELL23 { get; set; }
        public decimal? PRICESELL24 { get; set; }
        public decimal? PRICESELL25 { get; set; }
        public decimal? PRICESELL26 { get; set; }
        public decimal? PRICESELL27 { get; set; }
        public decimal? PRICESELL28 { get; set; }
        public decimal? PRICESELL29 { get; set; }
        public decimal? PRICESELL30 { get; set; }
        public decimal? PRICESELL31 { get; set; }
        public decimal? PRICESELL32 { get; set; }
        public decimal? PRICESELL33 { get; set; }
        public decimal? PRICESELL34 { get; set; }
        public decimal? PRICESELL35 { get; set; }
        public decimal? PRICESELL36 { get; set; }
        public decimal? PRICESELL37 { get; set; }
        public decimal? PRICESELL38 { get; set; }
        public decimal? PRICESELL39 { get; set; }
        public decimal? PRICESELL40 { get; set; }
        public decimal? PRICESELL41 { get; set; }
        public decimal? PRICESELL42 { get; set; }
        public decimal? PRICESELL43 { get; set; }
        #endregion
        #region compra
        public decimal? PRICEBUY1 { get; set; }
        public decimal? PRICEBUY2 { get; set; }
        public decimal? PRICEBUY3 { get; set; }
        public decimal? PRICEBUY4 { get; set; }
        public decimal? PRICEBUY5 { get; set; }
        public decimal? PRICEBUY6 { get; set; }
        public decimal? PRICEBUY7 { get; set; }
        public decimal? PRICEBUY8 { get; set; }
        public decimal? PRICEBUY9 { get; set; }
        public decimal? PRICEBUY10 { get; set; }
        public decimal? PRICEBUY11 { get; set; }
        public decimal? PRICEBUY12 { get; set; }
        public decimal? PRICEBUY13 { get; set; }
        public decimal? PRICEBUY14 { get; set; }
        public decimal? PRICEBUY15 { get; set; }
        public decimal? PRICEBUY16 { get; set; }
        public decimal? PRICEBUY17 { get; set; }
        public decimal? PRICEBUY18 { get; set; }
        public decimal? PRICEBUY19 { get; set; }
        public decimal? PRICEBUY20 { get; set; }
        public decimal? PRICEBUY21 { get; set; }
        public decimal? PRICEBUY22 { get; set; }
        public decimal? PRICEBUY1S { get; set; }
        public decimal? PRICEBUY2S { get; set; }
        public decimal? PRICEBUY3S { get; set; }
        public decimal? PRICEBUY4S { get; set; }
        public decimal? PRICEBUY5S { get; set; }
        public decimal? PRICEBUY6S { get; set; }
        public decimal? PRICEBUY7S { get; set; }
        public decimal? PRICEBUY8S { get; set; }
        public decimal? PRICEBUY9S { get; set; }
        public decimal? PRICEBUY10S { get; set; }
        public decimal? PRICEBUY11S { get; set; }
        public decimal? PRICEBUY12S { get; set; }
        public decimal? PRICEBUY13S { get; set; }
        public decimal? PRICEBUY14S { get; set; }
        public decimal? PRICEBUY15S { get; set; }
        public decimal? PRICEBUY16S { get; set; }
        public decimal? PRICEBUY17S { get; set; }
        public decimal? PRICEBUY18S { get; set; }
        public decimal? PRICEBUY19S { get; set; }
        public decimal? PRICEBUY20S { get; set; }
        public decimal? PRICEBUY21S { get; set; }
        public decimal? PRICEBUY22S { get; set; }
#endregion
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
