namespace Pedido.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public string ClienteCpf { get; set; }
        public string Lanche { get; set; }
        public string Acompanhamento { get; set; }
        public string Bebida { get; set; }
        public string Status { get; set; }
    }
}
