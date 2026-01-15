namespace SubirVentas.Models
{
    public class CATEGORIES : IEquatable<CATEGORIES>
    {
        public string? ID { get; set; }
        public string? NAME { get; set; }
        public string? PARENTID { get; set; }
        public bool Equals(CATEGORIES other)
        {
            if (other is null)
                return false;

            return this.ID == other.ID;
        }

        public override bool Equals(object obj) => Equals(obj as CATEGORIES);
        public override int GetHashCode() => ID?.GetHashCode() ?? 0;
    }
}
