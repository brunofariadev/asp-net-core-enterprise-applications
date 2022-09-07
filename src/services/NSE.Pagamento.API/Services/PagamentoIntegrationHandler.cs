using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Core.Messages.Integration;
using NSE.MessageBus;
using NSE.Pagamento.API.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Pagamento.API.Services
{
    public class PagamentoIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public PagamentoIntegrationHandler(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            //SetSubscribers();
            return Task.CompletedTask;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<PedidoIniciadoIntegrationEvent, ResponseMessage>(async request =>
                await AutorizarPagamento(request));
        }

        private async Task<ResponseMessage> AutorizarPagamento(PedidoIniciadoIntegrationEvent message)
        {
            using var scope = _serviceProvider.CreateScope();
            var pagamentoService = scope.ServiceProvider.GetRequiredService<IPagamentoService>();
            var pagamento = new Pagamentos
            {
                PedidoId = message.PedidoId,
                TipoPagamento = (TipoPagamentoEnum)message.TipoPagamento,
                Valor = message.Valor,
                CartaoCredito = new CartaoCredito(
                    message.NomeCartao, message.NumeroCartao, message.MesAnoVencimento, message.CVV)
            };

            var response = await pagamentoService.AutorizarPagamento(pagamento);
            return response;
        }
    }
}
