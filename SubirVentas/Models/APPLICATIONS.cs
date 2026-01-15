namespace SubirVentas.Models
{
    public class APPLICATIONS : IEquatable<APPLICATIONS>
    {
        public string? ID { get; set; }
        public DateTime? FECHA { get; set; }
        public bool Equals(APPLICATIONS other)
        {
            if (other is null)
                return false;

            return this.ID == other.ID;
        }

        public override bool Equals(object obj) => Equals(obj as APPLICATIONS);
        public override int GetHashCode() => ID?.GetHashCode() ?? 0;
    }
}
