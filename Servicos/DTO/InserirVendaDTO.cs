using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class InserirVendaDTO
    {
        public required string CompradorId { get; set; }

        public required string EventoId { get; set; }

        public int Quantidade { get; set; }
    }
}
