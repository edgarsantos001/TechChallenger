using Microsoft.AspNetCore.Mvc;
using PagamentoService.Models;
using PagamentoService.Models.Interface;
using PagamentoService.Models.Webhook;

namespace PagamentoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentosController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpPost]
        public IActionResult ProcessarPagamento([FromBody] PagamentoModel pagamento)
        {
            _pagamentoService.ProcessarPagamento(pagamento);
            return Ok();
        }

        [HttpPost("webhook")]
        public IActionResult ConfirmPagamento([FromBody] PagamentoWebhook webhook)
        {
            _pagamentoService.AtualizarStatusPagamento(webhook.PagamentoId, webhook.Status);
            return Ok();
        }
    }
}
