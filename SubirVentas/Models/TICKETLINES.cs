using System.ComponentModel.DataAnnotations;

namespace SubirVentas.Models
{
    public class TICKETLINES : IEquatable<TICKETLINES>
    {
        [Key]
        public string? ID { get; set; }
        public string? TICKET { get; set; }
        public int? LINE { get; set; }
        public string? PRODUCT { get; set; }
        public decimal? UNITS { get; set; }
        public decimal? PRICE { get; set; }
        public bool Equals(TICKETLINES other)
        {
            if (other is null)
                return false;

            return this.TICKET == other.TICKET && this.LINE == other.LINE;
        }

        public override bool Equals(object obj) => Equals(obj as TICKETLINES);
        public override int GetHashCode() => ID?.GetHashCode() ?? 0;
    }
}
