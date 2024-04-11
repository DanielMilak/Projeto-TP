using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class InserirCompradorDTO 
    { 
        public required string CPF { get; set; }

        public required string Nome { get; set; }

        public required string Sexo { get; set; }

        public DateTime DtNasc { get; set; }
        }
}
