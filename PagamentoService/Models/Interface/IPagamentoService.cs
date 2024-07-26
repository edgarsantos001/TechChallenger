using PagamentoService.Models.Webhook;

namespace PagamentoService.Models.Interface
{
    public interface IPagamentoService
    {
        void ProcessarPagamento(PagamentoModel pagamento);
        void AtualizarStatusPagamento(int id,  string status);
    }
}
