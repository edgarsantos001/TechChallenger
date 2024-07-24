using Microsoft.AspNetCore.Mvc;
using NotificationService.Models;
using NotificationService.Models.Interface;

namespace NotificationService.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacaoController : ControllerBase
    {
        private readonly INotificacaoService _notificationService;

        public NotificacaoController(INotificacaoService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public IActionResult SendNotification([FromBody] NotificacaoModel notification)
        {
            _notificationService.SendNotification(notification);
            return Ok();
        }
    }
}
