namespace PedidoService.Models
{
    public class PagamentoModel
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
    }
}
