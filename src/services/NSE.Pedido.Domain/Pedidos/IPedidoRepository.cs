using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace NSE.Pedido.Domain.Pedidos
{
    public interface IPedidoRepository : IRepository<Pedidoo>
    {
        Task<Pedidoo> ObterPorId(Guid id);
        Task<IEnumerable<Pedidoo>> ObterListaPorClienteId(Guid clienteId);
        void Adicionar(Pedidoo pedido);
        void Atualizar(Pedidoo pedido);

        DbConnection ObterConexao();


        /* Pedido Item */
        Task<PedidoItem> ObterItemPorId(Guid id);
        Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId);
    }
}
