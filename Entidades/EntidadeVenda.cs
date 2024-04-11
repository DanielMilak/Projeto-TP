namespace Entidades
{
    public class EntidadeVenda
    {
        public int Id { get; set; }

        public required string CompradorId { get; set; }

        public required string EventoId { get; set; }

        public int  Quantidade { get; set; }

        public Boolean Extornado { get; set; } = true;
    }

}
