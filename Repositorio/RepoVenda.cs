using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public interface IRepoVenda
    {
        void Inserir(EntidadeVenda venda);
        void Atualizar(EntidadeVenda venda);
        public EntidadeVenda BuscarId(int id);
        List<EntidadeVenda> BuscarTodos();
    }

    public class RepoVenda : IRepoVenda
    {
        private DataContext _dataContext;

        public object? Id { get; internal set; }

        public RepoVenda(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(EntidadeVenda venda)
        {
            _dataContext.Add(venda);

            _dataContext.SaveChanges();
        }

        public void Atualizar(EntidadeVenda venda)
        {
            _dataContext.Update(venda);

            _dataContext.SaveChanges();
        }

        public EntidadeVenda BuscarId(int id)
        {
            EntidadeVenda? venda = _dataContext.Venda.FirstOrDefault(venda => venda.Id == id);

            return venda ?? throw new Exception("Evento não encontrado");
        }

        public List<EntidadeVenda> BuscarTodos()
        {
            var venda = _dataContext.Venda.ToList();

            return venda;
        }
    }
}
