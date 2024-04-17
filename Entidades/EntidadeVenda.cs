﻿namespace Entidades
{
    public class EntidadeVenda
    {
        public int Id { get; set; }

        public required int CompradorId { get; set; }    

        public required int EventoId { get; set; }

        public int  Quantidade { get; set; }

        public Boolean Extornado { get; set; } = true;
        
        public EntidadeComprador Comprador { get; set; }
        
        public EntidadeVenda Evento { get; set; }

    }

}
