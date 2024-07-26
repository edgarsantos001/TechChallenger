namespace Pedido.Models.Interface
{
    public interface IPedidoService
    {
        void CreatePedido(PedidoModel pedido);
        PedidoModel GetPedidoById(int id);
        void UpdatePedidoStatus(int id, string status);
    }
}
