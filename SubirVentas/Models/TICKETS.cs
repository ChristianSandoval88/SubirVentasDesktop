namespace SubirVentas.Models
{
    public class TICKETS : IEquatable<TICKETS>
    {
        public string? ID { get; set; }
        public int? TICKETTYPE { get; set; }
        public int? TICKETID { get; set; }
        public string? PERSON { get; set; }
        public string? CUSTOMER { get; set; }
        public int? STATUS { get; set; }
        public decimal? TOTAL { get; set; }
        public bool Equals(TICKETS other)
        {
            if (other is null)
                return false;

            return this.ID == other.ID;
        }

        public override bool Equals(object obj) => Equals(obj as TICKETS);
        public override int GetHashCode() => ID?.GetHashCode() ?? 0;
    }
}
