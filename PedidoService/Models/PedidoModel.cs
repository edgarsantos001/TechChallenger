namespace Pedido.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public string? ClienteId { get; set; }
        public List<string> ProdutoIds { get; set; }
        public string? Status { get; set; }
    }
}
