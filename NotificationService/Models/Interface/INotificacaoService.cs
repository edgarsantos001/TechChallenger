namespace NotificationService.Models.Interface
{
    public interface INotificacaoService
    {
        void SendNotification(NotificacaoModel notification);
    }
}
