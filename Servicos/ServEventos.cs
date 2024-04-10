using Entidades;
using Repositorio;

namespace Servicos
{
    public interface IServEvento
    {
        void Inserir(InserirEventoDTO inserirEventoDto);
        List<Evento> BuscarTodos();
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
            var evento = new Evento();

            evento.Nome = inserirEventoDto.Nome;
            evento.Local = inserirEventoDto.Local;
            evento.Atracao = inserirEventoDto.Atracao;
            evento.ValorIngresso = inserirEventoDto.ValorIngresso;
            _repoEvento.Inserir(evento);
        }

        public List<Evento> BuscarTodos()
        {
            var eventos = _repoEvento.BuscarTodos();

            return eventos;
        }
    }
}
