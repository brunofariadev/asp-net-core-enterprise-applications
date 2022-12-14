// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NSE.Pagamento.API.Data;

namespace NSE.Pagamento.API.Migrations
{
    [DbContext(typeof(PagamentosContext))]
    partial class PagamentosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("NSE.Pagamento.API.Models.Pagamentos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TipoPagamento")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("NSE.Pagamento.API.Models.Transacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BandeiraCartao")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CodigoAutorizacao")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("CustoTransacao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("DataTransacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NSU")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("PagamentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TID")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PagamentoId");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("NSE.Pagamento.API.Models.Transacao", b =>
                {
                    b.HasOne("NSE.Pagamento.API.Models.Pagamentos", "Pagamento")
                        .WithMany("Transacoes")
                        .HasForeignKey("PagamentoId")
                        .IsRequired();

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("NSE.Pagamento.API.Models.Pagamentos", b =>
                {
                    b.Navigation("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
