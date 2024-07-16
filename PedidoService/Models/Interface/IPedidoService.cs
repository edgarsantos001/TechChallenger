namespace Pedido.Models.Interface
{
    public interface IPedidoService
    {
        PedidoModel CreatePedido(PedidoModel pedido);
        PedidoModel GetPedidoById(int id);
        PedidoModel UpdatePedidoStatus(int id, string status);
    }
}
