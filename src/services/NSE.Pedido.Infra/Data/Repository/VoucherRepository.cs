using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Pedido.Domain.Vouchers;
using System.Threading.Tasks;

namespace NSE.Pedido.Infra.Data.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidosContext _pedidosContext;

        public VoucherRepository(PedidosContext pedidosContext)
        {
            _pedidosContext = pedidosContext;
        }

        public IUnitOfWork UnitOfWork => _pedidosContext;

        public async Task<Voucher> ObterVoucherPorCodigo(string codigo)
        {
            return await _pedidosContext.Vouchers.FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        public void Atualizar(Voucher voucher)
        {
            _pedidosContext.Vouchers.Update(voucher);
        }

        public void Dispose()
        {
            _pedidosContext.Dispose();
        }
    }
}
