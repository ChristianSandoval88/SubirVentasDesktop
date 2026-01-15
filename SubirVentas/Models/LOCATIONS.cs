namespace SubirVentas.Models
{
    public class LOCATIONS : IEquatable<LOCATIONS>
    {
        public string? ID { get; set; }
        public string? NAME { get; set; }
        public bool Equals(LOCATIONS other)
        {
            if (other is null)
                return false;

            return this.ID == other.ID;
        }

        public override bool Equals(object obj) => Equals(obj as LOCATIONS);
        public override int GetHashCode() => ID?.GetHashCode() ?? 0;
    }
}
