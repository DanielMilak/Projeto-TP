using Entidades;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Repositorio;

namespace Servicos
{
    public interface IServEvento
    {
        void Inserir(InserirEventoDTO inserirEventoDto);
        public void Cancelar(int id, Boolean CancelarEvento);
        List<EntidadeEvento> BuscarTodos();
    }

    public class ServEvento : IServEvento
    {
        private IRepoEvento _repoEvento;

        public ServEvento(IRepoEvento repoEvento)
        {
            _repoEvento = repoEvento;
        }

        public void Inserir(InserirEventoDTO inserirEventoDto)
        {
            EntidadeEvento evento = new EntidadeEvento()
            {
                Nome = inserirEventoDto.Nome,
                Local = inserirEventoDto.Local,
                Atracao = inserirEventoDto.Atracao,
                ValorIngresso = inserirEventoDto.ValorIngresso,
                Cancelado = true
            };

            _repoEvento.Inserir(evento);
        }

        public void Cancelar(int id, Boolean CancelarEvento)
        {
            var eventoExistente = _repoEvento.BuscarId(id);

            eventoExistente.Cancelado = CancelarEvento;

            _repoEvento.Atualizar(eventoExistente);
        }

        public List<EntidadeEvento> BuscarTodos()
        {
            var eventos = _repoEvento.BuscarTodos();

            return eventos;
        }
    }
}
