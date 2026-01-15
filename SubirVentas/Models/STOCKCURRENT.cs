using System.ComponentModel.DataAnnotations;

namespace SubirVentas.Models
{
    public class STOCKCURRENT : IEquatable<STOCKCURRENT>
    {
        public string? LOCATION { get; set; }
        [Key]
        public string? PRODUCT { get; set; }
        public decimal? UNITS { get; set; }
        public bool Equals(STOCKCURRENT other)
        {
            if (other is null)
                return false;

            return this.LOCATION == other.LOCATION && this.PRODUCT == other.PRODUCT;
        }

        public override bool Equals(object obj) => Equals(obj as STOCKCURRENT);
        public override int GetHashCode() => System.HashCode.Combine(LOCATION, PRODUCT);
    }
}
