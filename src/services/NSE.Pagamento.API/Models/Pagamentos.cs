using NSE.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Pagamento.API.Models
{
    public class Pagamentos : Entity, IAggregateRoot
    {
        public Pagamentos()
        {
            Transacoes = new List<Transacao>();
        }

        public Guid PedidoId { get; set; }
        public TipoPagamentoEnum TipoPagamento { get; set; }
        public decimal Valor { get; set; }

        public CartaoCredito CartaoCredito { get; set; }

        // EF Relation
        public ICollection<Transacao> Transacoes { get; set; }

        public void AdicionarTransacao(Transacao transacao)
        {
            Transacoes.Add(transacao);
        }
    }
}
