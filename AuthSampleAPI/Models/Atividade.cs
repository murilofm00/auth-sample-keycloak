namespace AuthSampleAPI.Models
{
    public class Atividade
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string CreatedBy { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(Atividade other)
        {
            return other.Id == Id;
        }
    }
}
