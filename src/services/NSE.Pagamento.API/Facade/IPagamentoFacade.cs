using NSE.Pagamento.API.Models;
using System.Threading.Tasks;

namespace NSE.Pagamento.API.Facade
{
    public interface IPagamentoFacade
    {
        Task<Transacao> AutorizarPagamento(Pagamentos pagamento);
        Task<Transacao> CapturarPagamento(Transacao transacao);
        Task<Transacao> CancelarAutorizacao(Transacao transacao);
    }
}
