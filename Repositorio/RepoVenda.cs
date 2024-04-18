using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repositorio
{
    public interface IRepoVenda
    {
        void Inserir(EntidadeVenda venda);
        void Atualizar(EntidadeVenda venda);
        public EntidadeVenda BuscarId(int id);
        public void ExtornarVendaEvento(int eventoid);
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
        /* public void ExtornarVendaEvento(int eventoid)
         {
             List<EntidadeVenda>? venda = _dataContext.Venda.Where(venda => venda.EventoId == eventoid).ToList();
             for (int i = 0; i < venda.Count; i++)
             {
                 venda[i].Estornado = true;
             }
             _dataContext.Update(venda);

             _dataContext.SaveChanges();
         }
        */
        public void ExtornarVendaEvento(int eventoid)
        {
            List<EntidadeVenda>? vendas = _dataContext.Venda.Where(v => v.EventoId == eventoid).ToList();
            foreach (var venda in vendas)
            {
                venda.Estornado = true;
                _dataContext.Update(venda); // Atualiza cada venda individualmente no contexto
            }

            _dataContext.SaveChanges();
        }



public List<EntidadeVenda> BuscarTodos()
        {
            var venda = _dataContext.Venda.Include(p => p.Comprador).Include(p => p.Evento).ToList();

            return venda;
        }
    }
}
