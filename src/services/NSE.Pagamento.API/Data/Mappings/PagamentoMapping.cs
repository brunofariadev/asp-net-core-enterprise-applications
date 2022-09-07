using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Pagamento.API.Models;

namespace NSE.Pagamento.API.Data.Mappings
{
    public class PagamentoMapping : IEntityTypeConfiguration<Pagamentos>
    {
        public void Configure(EntityTypeBuilder<Pagamentos> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Ignore(c => c.CartaoCredito);

            // 1 : N => Pagamento : Transacao
            builder.HasMany(c => c.Transacoes)
                .WithOne(c => c.Pagamento)
                .HasForeignKey(c => c.PagamentoId);

            builder.ToTable("Pagamentos");
        }
    }
}
