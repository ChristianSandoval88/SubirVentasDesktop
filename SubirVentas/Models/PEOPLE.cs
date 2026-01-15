namespace SubirVentas.Models
{
    public class PEOPLE : IEquatable<PEOPLE>
    {
        public string? ID { get; set; }
        public string? NAME { get; set; }
        public string? CARD { get; set; }
        public string? ROLE { get; set; }
        public bool VISIBLE { get; set; }
        public bool Equals(PEOPLE other)
        {
            if (other is null)
                return false;

            return this.ID == other.ID;
        }

        public override bool Equals(object obj) => Equals(obj as PEOPLE);
        public override int GetHashCode() => (ID).GetHashCode();
    }
}
