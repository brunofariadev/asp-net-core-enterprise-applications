using NSE.Core.Messages.Integration;
using NSE.Pagamento.API.Models;
using System;
using System.Threading.Tasks;

namespace NSE.Pagamento.API.Services
{
    public interface IPagamentoService
    {
        Task<ResponseMessage> AutorizarPagamento(Pagamentos pagamento);
        Task<ResponseMessage> CapturarPagamento(Guid pedidoId);
        Task<ResponseMessage> CancelarPagamento(Guid pedidoId);
    }
}