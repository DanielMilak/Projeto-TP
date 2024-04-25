using Entidades;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
using Repositorio;

namespace Servicos
{
    public interface IServEvento
    {
        void Inserir(InserirEventoDTO inserirEventoDto);
        public void Cancelar(int id, Boolean CancelarEvento);
        List<EntidadeEvento> BuscarTodos();
        public void AtualizaIngressos(int id, int quantidadeingresso);
        public List<EntidadeEvento> BuscarMaisVendidos();
    }

    public class ServEvento : IServEvento
    {
        private IRepoEvento _repoEvento;
        private IRepoVenda _repoVenda;

        public ServEvento(IRepoEvento repoEvento, IRepoVenda repoVenda)
        {
            _repoEvento = repoEvento;
            _repoVenda = repoVenda;
        }

        public void Inserir(InserirEventoDTO inserirEventoDto)
        {
            EntidadeEvento evento = new EntidadeEvento()
            {
                Nome = inserirEventoDto.Nome,
                Local = inserirEventoDto.Local,
                Atracao = inserirEventoDto.Atracao,
                ValorIngresso = inserirEventoDto.ValorIngresso,
                QuantidadeIngresso = inserirEventoDto.QuantidadeIngresso
               
            };

            _repoEvento.Inserir(evento);
        }

        public void Cancelar(int id, Boolean CancelarEvento)
        {
            var eventoExistente = _repoEvento.BuscarId(id);

            eventoExistente.Cancelado = CancelarEvento;

            _repoVenda.ExtornarVendaEvento(id);

            _repoEvento.Atualizar(eventoExistente);
        }

        public List<EntidadeEvento> BuscarTodos()
        {
            var eventos = _repoEvento.BuscarTodos();

            return eventos;
        }
        public void AtualizaIngressos(int id, int quantidadeingresso)
        {
            var eventoExistente = _repoEvento.BuscarId(id);

            eventoExistente.QuantidadeIngresso -= quantidadeingresso;
            eventoExistente.QuantidadeVendida += quantidadeingresso;

            _repoEvento.Atualizar(eventoExistente);
        }
        
        public List<EntidadeEvento> BuscarMaisVendidos()
        {
            var eventos = _repoEvento.BuscarMaisVendidos();

            return eventos;
        }
    }
}
