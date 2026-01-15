namespace SubirVentas.Models
{
    public class ROLES : IEquatable<ROLES>
    {
        public string? ID { get; set; }
        public string? NAME { get; set; }
        public bool Equals(ROLES other)
        {
            if (other is null)
                return false;

            return this.ID == other.ID;
        }

        public override bool Equals(object obj) => Equals(obj as ROLES);
        public override int GetHashCode() => ID?.GetHashCode() ?? 0;
    }
}
