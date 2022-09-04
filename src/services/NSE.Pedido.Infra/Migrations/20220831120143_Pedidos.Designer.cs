﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NSE.Pedido.Infra.Data;

namespace NSE.Pedido.Infra.Migrations
{
    [DbContext(typeof(PedidosContext))]
    [Migration("20220831120143_Pedidos")]
    partial class Pedidos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.HasSequence<int>("MinhaSequencia")
                .StartsAt(1000L);

            modelBuilder.Entity("NSE.Pedido.Domain.Pedidos.PedidoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProdutoImagem")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProdutoNome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoItems");
                });

            modelBuilder.Entity("NSE.Pedido.Domain.Pedidos.Pedidoo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR MinhaSequencia");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PedidoStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("VoucherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("VoucherUtilizado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("VoucherId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("NSE.Pedido.Domain.Vouchers.Voucher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUtilizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Percentual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("TipoDesconto")
                        .HasColumnType("int");

                    b.Property<bool>("Utilizado")
                        .HasColumnType("bit");

                    b.Property<decimal?>("ValorDesconto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("NSE.Pedido.Domain.Pedidos.PedidoItem", b =>
                {
                    b.HasOne("NSE.Pedido.Domain.Pedidos.Pedidoo", "Pedido")
                        .WithMany("PedidoItems")
                        .HasForeignKey("PedidoId")
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("NSE.Pedido.Domain.Pedidos.Pedidoo", b =>
                {
                    b.HasOne("NSE.Pedido.Domain.Vouchers.Voucher", "Voucher")
                        .WithMany()
                        .HasForeignKey("VoucherId");

                    b.OwnsOne("NSE.Pedido.Domain.Pedidos.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("PedidooId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("Cep")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Cidade")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Complemento")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Complemento");

                            b1.Property<string>("Estado")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Estado");

                            b1.Property<string>("Logradouro")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Logradouro");

                            b1.Property<string>("Numero")
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Numero");

                            b1.HasKey("PedidooId");

                            b1.ToTable("Pedidos");

                            b1.WithOwner()
                                .HasForeignKey("PedidooId");
                        });

                    b.Navigation("Endereco");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("NSE.Pedido.Domain.Pedidos.Pedidoo", b =>
                {
                    b.Navigation("PedidoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
