using FluentValidation.Results;
using NSE.Core.Messages.Integration;
using NSE.Pagamento.API.Facade;
using NSE.Pagamento.API.Models;
using System;
using System.Threading.Tasks;

namespace NSE.Pagamento.API.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoFacade _pagamentoFacade;
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoService(IPagamentoFacade pagamentoFacade,
                                IPagamentoRepository pagamentoRepository)
        {
            _pagamentoFacade = pagamentoFacade;
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<ResponseMessage> AutorizarPagamento(Pagamentos pagamento)
        {
            var transacao = await _pagamentoFacade.AutorizarPagamento(pagamento);
            var validationResult = new ValidationResult();

            if (transacao.Status != StatusTransacaoEnum.Autorizado)
            {
                validationResult.Errors.Add(new ValidationFailure("Pagamento",
                        "Pagamento recusado, entre em contato com a sua operadora de cartão"));

                return new ResponseMessage(validationResult);
            }

            pagamento.AdicionarTransacao(transacao);
            _pagamentoRepository.AdicionarPagamento(pagamento);

            if (!await _pagamentoRepository.UnitOfWork.Commit())
            {
                validationResult.Errors.Add(new ValidationFailure("Pagamento",
                    "Houve um erro ao realizar o pagamento."));
                // Cancelar pagamento no gateway
                await CancelarPagamento(pagamento.PedidoId);
                return new ResponseMessage(validationResult);
            }

            return new ResponseMessage(validationResult);
        }

        public Task<ResponseMessage> CancelarPagamento(Guid pedidoId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage> CapturarPagamento(Guid pedidoId)
        {
            throw new NotImplementedException();
        }
    }
}
