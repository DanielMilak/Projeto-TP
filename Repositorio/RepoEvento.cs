using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public interface IRepoEvento
    {
        void Inserir(EntidadeEvento evento);
        void Atualizar(EntidadeEvento evento);
        public EntidadeEvento BuscarId(int id);
        List<EntidadeEvento> BuscarTodos();
        public List<EntidadeEvento> BuscarMaisVendidos();
    }

    public class RepoEvento : IRepoEvento
    {
        private DataContext _dataContext;

        public RepoEvento(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(EntidadeEvento evento)
        {
            _dataContext.Add(evento);

            _dataContext.SaveChanges();
        }

        public void Atualizar(EntidadeEvento evento)
        {
            _dataContext.Update(evento);

            _dataContext.SaveChanges();
        }

        public EntidadeEvento BuscarId(int id)
        {
            EntidadeEvento? evento = _dataContext.Evento.FirstOrDefault(evento => evento.Id == id);

            return evento ?? throw new Exception("Evento não encontrado");
        }

        public List<EntidadeEvento> BuscarTodos()
        {
            var evento = _dataContext.Evento.ToList();

            return evento;
        }
        
        public List<EntidadeEvento> BuscarMaisVendidos()
        {
            var evento = _dataContext.Evento.OrderByDescending(evento => evento.QuantidadeVendida).Take(3).ToList();

            return evento;
        }
        
    }
}
