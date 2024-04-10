using Entidades;

namespace Repositorio
{
    public interface IRepoEvento
    {
        void Inserir(Evento evento);
        List<Evento> BuscarTodos();
    }

    public class RepoEvento : IRepoEvento
    {
        private DataContext _dataContext;

        public RepoEvento(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Evento evento)
        {
            _dataContext.Add(evento);

            _dataContext.SaveChanges();
        }

        public List<Evento> BuscarTodos()
        {
            var evento = _dataContext.Evento.ToList();

            return evento;
        }
    }
}
