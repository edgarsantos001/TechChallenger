namespace NotificationService.Models
{
    public class NotificacaoModel
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
        public DateTime? DataEnvio { get; set; }
    }
}
