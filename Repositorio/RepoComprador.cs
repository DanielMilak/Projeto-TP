using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public interface IRepoComprador
    {
        void Inserir(EntidadeComprador comprador);
        void Atualizar(EntidadeComprador comprador);
        public EntidadeComprador BuscarId(int id);
        List<EntidadeComprador> BuscarTodos();
    }

    public class RepoComprador : IRepoComprador
    {
        private DataContext _dataContext;

        public object? Id { get; internal set; }

        public RepoComprador(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(EntidadeComprador comprador)
        {
            _dataContext.Add(comprador);

            _dataContext.SaveChanges();
        }

        public void Atualizar(EntidadeComprador comprador)
        {
            _dataContext.Update(comprador);

            _dataContext.SaveChanges();
        }

        public EntidadeComprador BuscarId(int id)
        {
            EntidadeComprador? comprador = _dataContext.Comprador.FirstOrDefault(comprador => comprador.Id == id);

            return comprador ?? throw new Exception("Comprador não encontrado");
        }

        public List<EntidadeComprador> BuscarTodos()
        {
            var comprador = _dataContext.Comprador.ToList();

            return comprador;
        }
    }
}
