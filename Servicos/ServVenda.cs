using Entidades;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
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
        private IRepoEvento _repoEvento;
        private IRepoComprador _repoComprador;
        private IServEvento _servEvento;
        public ServVenda(IRepoVenda repoVenda, IRepoComprador repoComprador, IRepoEvento repoEvento, IServEvento servEvento)
        {
            _repoVenda = repoVenda;
            _servEvento = servEvento;
            _repoEvento = repoEvento;
            _repoComprador = repoComprador;

        }
        
        public void Inserir(InserirVendaDTO inserirVendaDto)
        {
            var evento = _repoEvento.BuscarId(inserirVendaDto.EventoId);
            if (evento.QuantidadeIngresso < inserirVendaDto.Quantidade) 
            {
                throw new Exception("Quantidade de Ingresso disponivel no evento nao e suficiente");
            }
            if (inserirVendaDto.Quantidade < 1)
            {
                throw new Exception("Nao foi informada a quantidade de ingressos");
            }
            _repoComprador.BuscarId(inserirVendaDto.CompradorId); 
            
            EntidadeVenda venda = new EntidadeVenda()
            {
                CompradorId = inserirVendaDto.CompradorId,
                EventoId = inserirVendaDto.EventoId,
                Quantidade = inserirVendaDto.Quantidade
            };

            _repoVenda.Inserir(venda);
            _servEvento.AtualizaIngressos(inserirVendaDto.EventoId, inserirVendaDto.Quantidade);
        }

        public void Extornar(int id, Boolean ExtornarVenda)
        {
            EntidadeVenda vendaExistente = _repoVenda.BuscarId(id);
            var QuantidadeAdicionar = vendaExistente.Quantidade * -1;
        
            vendaExistente.Estornado = ExtornarVenda;

            _repoVenda.Atualizar(vendaExistente);
            _servEvento.AtualizaIngressos(vendaExistente.EventoId, QuantidadeAdicionar);
        }

        public List<EntidadeVenda> BuscarTodos()
        {
            var venda = _repoVenda.BuscarTodos();

            return venda;
        }
    }
}
