using Entidades;
using Repositorio;

namespace Servicos
{
    public interface IServPizzaria
    {
        void Inserir(InserirPizzariaDTO inserirPizzariaDto);
        List<Pizzaria> BuscarTodos();
    }

    public class ServPizzaria : IServPizzaria
    {
        private IRepoPizzaria _repoPizzaria;

        public ServPizzaria(IRepoPizzaria repoPizzaria)
        {
            _repoPizzaria = repoPizzaria;
        }

        public void Inserir(InserirPizzariaDTO inserirPizzariaDto)
        {
            var pizzaria = new Pizzaria();

            pizzaria.Nome = inserirPizzariaDto.Nome;
            pizzaria.Telefone = inserirPizzariaDto.Telefone;
            pizzaria.Endereco = inserirPizzariaDto.Endereco;

            ValidacoesAntesDeInserir(pizzaria);

            _repoPizzaria.Inserir(pizzaria);
        }

        public void ValidacoesAntesDeInserir(Pizzaria pizzaria)
        {
            if (pizzaria.Nome.Length < 40)
            {
                throw new Exception("Nome inválido. Deve possuir no mínimo 40 caracteres.");
            }
        }

        public List<Pizzaria> BuscarTodos()
        {
            var pizzarias = _repoPizzaria.BuscarTodos();

            return pizzarias;
        }
    }
}
