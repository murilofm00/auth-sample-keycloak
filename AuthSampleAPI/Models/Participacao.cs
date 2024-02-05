namespace AuthSampleAPI.Models
{
    public class Participacao: IEquatable<Participacao>
    {
        public Guid IdAtividade { get; set; }
        public required string IdUsuario { get; set;}
        public required string Resposta { get; set;}

        public override int GetHashCode()
        {
            return HashCode.Combine(IdAtividade, IdUsuario);
        }

        public bool Equals(Participacao? other)
        {
            return other?.IdUsuario == IdUsuario && other.IdAtividade == IdAtividade;
        }
    }
}
