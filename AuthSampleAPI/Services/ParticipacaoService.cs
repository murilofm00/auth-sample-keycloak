using AuthSampleAPI.Models;

namespace AuthSampleAPI.Services
{
    public class ParticipacaoService
    {
        private readonly HashSet<Participacao> _participacoes = new();

        public void Adicionar(Participacao atividade)
        {
            if(_participacoes.Contains(atividade))
            {
                _participacoes.Remove(atividade);
            }
            _participacoes.Add(atividade);
        }

        public void Adicionar(Guid idAtividade, string idUsuario, string resposta)
        {
            var participacao = new Participacao { IdAtividade = idAtividade, IdUsuario = idUsuario, Resposta = resposta };

            Adicionar(participacao);
        }

        public IEnumerable<Participacao> ListarTodas()
        {
            return _participacoes;
        }

        public IEnumerable<Participacao> ListarPorUsuario(string idUsuario)
        {
            return _participacoes.Where(x => x.IdUsuario == idUsuario);
        }

        public Participacao? Obter(Guid idAtividade, string idUsuario)
        {
            return _participacoes.FirstOrDefault(x => x.IdAtividade == idAtividade && x.IdUsuario == idUsuario);
        }

        public void Remover(Guid idAtividade, string idUsuario)
        {
            _participacoes.RemoveWhere(x => x.IdAtividade == idAtividade && x.IdUsuario == idUsuario);
        }
    }
}
