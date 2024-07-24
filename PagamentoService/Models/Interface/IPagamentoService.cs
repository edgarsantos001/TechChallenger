using PagamentoService.Models.Webhook;

namespace PagamentoService.Models.Interface
{
    public interface IPagamentoService
    {
        PagamentoModel CreatePagamento(PagamentoModel pagamento);
        bool ConfirmPagamento(PagamentoWebhook webhook);
    }
}
