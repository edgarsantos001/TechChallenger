using PagamentoService.Models.Interface;
using PagamentoService.Models.Webhook;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using PagamentoService.Models;

namespace PagamentoService.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly List<PagamentoModel> _pagamentos = new List<PagamentoModel>();

        public PagamentoModel CreatePagamento(PagamentoModel pagamento)
        {
            pagamento.Id = _pagamentos.Count + 1;
            pagamento.Status = "Pending";
            _pagamentos.Add(pagamento);

            // Publish to RabbitMQ
            PublishMessage(pagamento);

            return pagamento;
        }

        public bool ConfirmPagamento(PagamentoWebhook webhook)
        {
            var pagamento = _pagamentos.FirstOrDefault(p => p.Id == webhook.PagamentoId);
            if (pagamento != null)
            {
                pagamento.Status = webhook.Status;
                // Notify PedidoService and NotificationService
                PublishMessage(pagamento);
                return true;
            }
            return false;
        }

        private void PublishMessage(PagamentoModel pagamento)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "PagamentoQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = JsonSerializer.Serialize(pagamento);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "PagamentoQueue",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
