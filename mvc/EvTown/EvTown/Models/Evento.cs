namespace EvTown.Models
{
    public class Evento
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Categoria { get; set; }
        public int Acesso { get; set; }
        public int Pagamento { get; set; }
        public DateTime DataEvento { get; set; }
    }
}