using System.ComponentModel.DataAnnotations;

namespace SubirVentas.Models
{
    public class CLOSEDCASH : IEquatable<CLOSEDCASH>
    {
        [Key]
        public string? MONEY { get; set; }
        public string? HOST { get; set; }
        public int? HOSTSEQUENCE { get; set; }
        public DateTime? DATESTART { get; set; }
        public DateTime? DATEEND { get; set; }
        public string? ACTIVECASH { get; set; }
        public bool Equals(CLOSEDCASH other)
        {
            if (other is null)
                return false;

            return this.MONEY == other.MONEY;
        }

        public override bool Equals(object obj) => Equals(obj as CLOSEDCASH);
        public override int GetHashCode() => MONEY?.GetHashCode() ?? 0;
    }
}
