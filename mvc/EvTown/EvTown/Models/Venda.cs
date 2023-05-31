namespace EvTown.Models
{
    public class Venda
    {
        public int Id { get; set; }

        public string EventoId { get; set; }

        public string ParceiroId { get; set; }

        public DateTime DataEvento { get; set; }

        public decimal Valor { get; set; }
    }
}
