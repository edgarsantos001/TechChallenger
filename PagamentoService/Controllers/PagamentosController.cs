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
        public IActionResult CreatePagamento([FromBody] PagamentoModel pagamento)
        {
            var newPagamento = _pagamentoService.CreatePagamento(pagamento);
            if (newPagamento != null)
            {
                return Ok(newPagamento);
            }
            return BadRequest("Error creating pagamento.");
        }

        [HttpPost("webhook")]
        public IActionResult ConfirmPagamento([FromBody] PagamentoWebhook webhook)
        {
            var result = _pagamentoService.ConfirmPagamento(webhook);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Error confirming pagamento.");
        }
    }
}
