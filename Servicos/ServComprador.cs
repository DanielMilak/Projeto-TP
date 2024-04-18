using Entidades;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Repositorio;
using Servicos;

namespace Servicos
{
    public interface IServComprador
    {
        void Inserir(InserirCompradorDTO inserirCompradorDto);
        public void Cancelar(int id, Boolean CancelarComprador);
        List<EntidadeComprador> BuscarTodos();
    }

    public class ServComprador : IServComprador
    {
        private IRepoComprador _repoComprador;

        public ServComprador(IRepoComprador repoComprador)
        {
            _repoComprador = repoComprador;
        }

        public void Inserir(InserirCompradorDTO inserirCompradorDto)
        {
            EntidadeComprador comprador = new EntidadeComprador()
            {
                Nome = inserirCompradorDto.Nome,
                CPF = inserirCompradorDto.CPF,
                Sexo = inserirCompradorDto.Sexo
                //Cancelado = false
            };

            _repoComprador.Inserir(comprador);
        }

        public void Cancelar(int id, Boolean CancelarComprador)
        {
            var compradorExistente = _repoComprador.BuscarId(id);

            compradorExistente.Cancelado = CancelarComprador;

            _repoComprador.Atualizar(compradorExistente);
        }

        public List<EntidadeComprador> BuscarTodos()
        {
            var comprador = _repoComprador.BuscarTodos();

            return comprador;
        }
    }
}
