using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class InserirEventoDTO
    {
        public string Nome { get; set; }

        public string Local { get; set; }

        public string Atracao { get; set; }

        public decimal ValorIngresso { get; set; }
    }
}
