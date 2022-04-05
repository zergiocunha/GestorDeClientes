﻿// <auto-generated />
using System;
using GestorDeClientes.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestorDeClientes.Migrations
{
    [DbContext(typeof(GCContext))]
    partial class GCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GestorDeClientes.Models.Carrinho.ClsCarrinho", b =>
                {
                    b.Property<int>("IdCarrinho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCarrinho"), 1L, 1);

                    b.Property<int>("Cliente")
                        .HasColumnType("int");

                    b.Property<int>("TotalGeral")
                        .HasColumnType("int");

                    b.HasKey("IdCarrinho");

                    b.HasIndex("Cliente");

                    b.ToTable("Carrinho");
                });

            modelBuilder.Entity("GestorDeClientes.Models.Carrinho.ClsCarrinhoItens", b =>
                {
                    b.Property<int>("IdItens")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdItens"), 1L, 1);

                    b.Property<int>("Produto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("SubTotal")
                        .HasColumnType("int");

                    b.HasKey("IdItens");

                    b.HasIndex("Produto");

                    b.ToTable("CarrinhoItens");
                });

            modelBuilder.Entity("GestorDeClientes.Models.Cliente.ClsCliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Telefone")
                        .HasColumnType("int");

                    b.Property<int?>("Telefone2")
                        .HasColumnType("int");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("GestorDeClientes.Models.Cliente.ClsClienteEndereco", b =>
                {
                    b.Property<int>("IdClienteEndereco")
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClienteEndereco");

                    b.ToTable("ClienteEndereco");
                });

            modelBuilder.Entity("GestorDeClientes.Models.Produto.ClsProduto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduto"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("IdProduto");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("GestorDeClientes.Models.Carrinho.ClsCarrinho", b =>
                {
                    b.HasOne("GestorDeClientes.Models.Cliente.ClsCliente", null)
                        .WithMany()
                        .HasForeignKey("Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestorDeClientes.Models.Carrinho.ClsCarrinhoItens", b =>
                {
                    b.HasOne("GestorDeClientes.Models.Produto.ClsProduto", null)
                        .WithMany()
                        .HasForeignKey("Produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestorDeClientes.Models.Cliente.ClsClienteEndereco", b =>
                {
                    b.HasOne("GestorDeClientes.Models.Cliente.ClsCliente", null)
                        .WithMany()
                        .HasForeignKey("IdClienteEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
