using System.ComponentModel.DataAnnotations;

namespace SubirVentas.Models
{
    public class PRODUCTS_CAT : IEquatable<PRODUCTS_CAT>
    {
        [Key]
        public string? PRODUCT { get; set; }
        public bool Equals(PRODUCTS_CAT other)
        {
            if (other is null)
                return false;

            return this.PRODUCT == other.PRODUCT;
        }

        public override bool Equals(object obj) => Equals(obj as PRODUCTS_CAT);
        public override int GetHashCode() => PRODUCT?.GetHashCode() ?? 0;
    }
}
