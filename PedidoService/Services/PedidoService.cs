using Pedido.Models;
using Pedido.Models.Interface;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;
using PedidoService.Models;

namespace Pedido.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly List<PedidoModel> _pedido = new List<PedidoModel>();

        public PedidoService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                var channel = connection.CreateModel();
                channel.QueueDeclare(queue: "PagamentoQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var pagamento = JsonSerializer.Deserialize<PagamentoModel>(message);

                    if(pagamento != null)
                    {
                        UpdatePedidoStatus(pagamento.PedidoId, pagamento.Status);
                    }
                };
                 channel.BasicConsume(queue: "PagamentoQueue",
                                     autoAck: true,
                                     consumer: consumer);
            }
        }

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
        private void PublishMessage(PedidoModel pedido)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "PedidoQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = JsonSerializer.Serialize(pedido);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "PedidoQueue",
                                     basicProperties: null,
                                     body: body);
            }
        }


    }
}
