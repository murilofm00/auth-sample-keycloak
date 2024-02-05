using AuthSampleAPI.Models;

namespace AuthSampleAPI.Services
{
    public class AtividadesService
    {
        private HashSet<Atividade> _activities = new()
        {
            new Atividade {Id=Guid.NewGuid(), CreatedBy="cfceff6a-1c60-4fa2-85f5-3b869bd84cf3", Nome= "Responda a atividade 1" },
            new Atividade {Id=Guid.NewGuid(), CreatedBy="cfceff6a-1c60-4fa2-85f5-3b869bd84cf3", Nome= "Responda a atividade 2" },
            new Atividade {Id=Guid.NewGuid(), CreatedBy="cfceff6a-1c60-4fa2-85f5-3b869bd84cf3", Nome= "Responda a atividade 3" },
        };

        public void Adicionar(Atividade atividade)
        {
            _activities.Add(atividade);
        }

        public void Adicionar(string nome, string idUsuario)
        {
            _activities.Add(new Atividade { Id=Guid.NewGuid(), CreatedBy = nome, Nome= idUsuario });
        }

        public IEnumerable<Atividade> ListarTodas()
        {
            return _activities;
        }

        public IEnumerable<Atividade> ListarPorUsuario(string idUsuario)
        {
            return _activities.Where(x => x.CreatedBy == idUsuario);
        }

        public Atividade? Obter(Guid id)
        {
            return _activities.FirstOrDefault(x => x.Id == id);
        }

        public void Remover(Guid id)
        {
            _activities.RemoveWhere(x => x.Id == id);
        }
    }
}
