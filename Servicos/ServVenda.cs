using Entidades;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Repositorio;

namespace Servicos
{
    public interface IServVenda
    {
        void Inserir(InserirVendaDTO inserirVendaDto);
        public void Extornar(int id, Boolean ExtornarVenda);
        List<EntidadeVenda> BuscarTodos();
    }

    public class ServVenda : IServVenda
    {
        private IRepoVenda _repoVenda;

        public ServVenda(IRepoVenda repoVenda)
        {
            _repoVenda = repoVenda;
        }
        
        public void Inserir(InserirVendaDTO inserirVendaDto)
        {
            EntidadeVenda venda = new EntidadeVenda()
            {
                CompradorId = inserirVendaDto.CompradorId,
                EventoId = inserirVendaDto.EventoId,
                Quantidade = inserirVendaDto.Quantidade
            };

            _repoVenda.Inserir(venda);
        }

        public void Extornar(int id, Boolean ExtornarVenda)
        {
            var vendaExistente = _repoVenda.BuscarId(id);

            vendaExistente.Extornado = ExtornarVenda;

            _repoVenda.Atualizar(vendaExistente);
        }

        public List<EntidadeVenda> BuscarTodos()
        {
            var venda = _repoVenda.BuscarTodos();

            return venda;
        }
    }
}
