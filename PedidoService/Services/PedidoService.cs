using Pedido.Models;
using Pedido.Models.Interface;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;
using PedidoService.Models;
using PedidoService.Data;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Pedido.Services
{
    public class PedidoService : IPedidoService
    {

        private readonly AppDbContext _context;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        
        public PedidoService(AppDbContext context)
        {
            _context = context;

            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "pedidoQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

        }

        public void CreatePedido(PedidoModel pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(pedido));
            _channel.BasicPublish(exchange: "",
                                 routingKey: "pedidoQueue",
                                 basicProperties: null,
                                 body: body);
        }

        public PedidoModel GetPedidoById(int id)
        {
            return _context.Pedidos.FirstOrDefault(p => p.Id == id);
        }

        public void UpdatePedidoStatus(int id, string status)
        {
            var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == id);

            if (pedido != null)
            {
                pedido.Status = status;
                _context.Pedidos.Update(pedido);
                _context.SaveChanges();


                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(pedido));
                _channel.BasicPublish(exchange: "",
                                     routingKey: "pedidoQueue",
                                     basicProperties: null,
                                     body: body);
            
            }
        }
    }
}
