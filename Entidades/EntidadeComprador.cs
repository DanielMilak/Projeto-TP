using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadeComprador
    {

        public int Id { get; set; }
        public required string CPF { get; set; }

        public required string Nome { get; set; }

        public required string Sexo { get; set; }

        public DateTime DtNasc { get; set; }

        public Boolean Cancelado { get; set; }

    }
}
