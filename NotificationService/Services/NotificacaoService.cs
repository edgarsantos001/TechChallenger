using NotificationService.Data;
using NotificationService.Models;
using NotificationService.Models.Interface;
using RabbitMQ.Client;
using System.Runtime.CompilerServices;

namespace NotificationService.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly AppDbContext _context;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public NotificacaoService(AppDbContext context)
        {
            _context = context;
            var factory = new ConnectionFactory() { HostName = "rabbitmq", UserName = "guest", Password = "guest" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "notificacaoQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void SendNotification(NotificacaoModel notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();

            string message = $"Pedido {notification.PedidoId} - {notification.Status} - {notification.Message}";
            var body = System.Text.Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "",
                                 routingKey: "notificacaoQueue",
                                 basicProperties: null,
                                 body: body);
           
        }
    }
}
