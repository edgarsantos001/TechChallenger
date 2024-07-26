using PagamentoService.Models.Interface;
using PagamentoService.Models.Webhook;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using PagamentoService.Models;
using System.Runtime.CompilerServices;
using PagamentoService.Data;

namespace PagamentoService.Services
{
    public class PagamentoService : IPagamentoService
    {

        private readonly AppDbContext _context;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public PagamentoService(AppDbContext context)
        {
            _context = context;
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "pagamentoQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void ProcessarPagamento(PagamentoModel pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();

            var pagamentoJson = JsonSerializer.Serialize(pagamento);
            var body = Encoding.UTF8.GetBytes(pagamentoJson);

            _channel.BasicPublish(exchange: "",
                                routingKey: "pagamentoQueue",
                                basicProperties: null,
                                body: body);
        }


        public void AtualizarStatusPagamento(int id, string status)
        {
            var pagamento = _context.Pagamentos.Find(id);
            if (pagamento != null)
            {
                pagamento.Status = status;
                _context.Pagamentos.Update(pagamento);
                _context.SaveChanges();
                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(pagamento));
                _channel.BasicPublish(exchange: "",
                                    routingKey: "pagamentoQueue",
                                    basicProperties: null,
                                    body: body);

            }
        }


    }
}
