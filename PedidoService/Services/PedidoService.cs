using Pedido.Models;
using Pedido.Models.Interface;

namespace Pedido.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly List<PedidoModel> _pedido = new List<PedidoModel>();

        public PedidoModel CreatePedido(PedidoModel pedido)
        {
            pedido.Id = _pedido.Count + 1;
            pedido.Status = "Recebido";
            _pedido.Add(pedido);

            return pedido;
        }

        public PedidoModel GetPedidoById(int id)
        {
            return _pedido.FirstOrDefault(p => p.Id == id);
        }

        public PedidoModel UpdatePedidoStatus(int id, string status)
        {
            var pedido = _pedido.FirstOrDefault(p => p.Id == id);

            if (pedido != null)
                pedido.Status = status;
            
            return pedido;
        }
    }
}
