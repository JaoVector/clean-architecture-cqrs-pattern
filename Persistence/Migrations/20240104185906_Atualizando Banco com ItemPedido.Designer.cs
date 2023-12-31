﻿// <auto-generated />
using System;
using FollowMe.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FollowMe.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240104185906_Atualizando Banco com ItemPedido")]
    partial class AtualizandoBancocomItemPedido
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FollowMe.Domain.Entities.Carrinho", b =>
                {
                    b.Property<Guid>("CarrinhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DataExclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CarrinhoId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Carrinho");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Endereco", b =>
                {
                    b.Property<Guid>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DataExclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EnderecoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.ItemCarrinho", b =>
                {
                    b.Property<Guid>("ItemCarrinhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarrinhoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CodProduto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DataExclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ItemCarrinhoId");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("CodProduto");

                    b.ToTable("ItemCarrinho");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.ItemPedido", b =>
                {
                    b.Property<Guid>("ItemPedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CodProduto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ItemPedidoId");

                    b.HasIndex("CodProduto");

                    b.HasIndex("PedidoId");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Pedido", b =>
                {
                    b.Property<Guid>("CodPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodRastreio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DataExclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EnderecoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CodPedido");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("CodProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DataExclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("CodProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("DataAtualizacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataCriacao")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DataExclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Carrinho", b =>
                {
                    b.HasOne("FollowMe.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Carrinho")
                        .HasForeignKey("FollowMe.Domain.Entities.Carrinho", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("FollowMe.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Enderecos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.ItemCarrinho", b =>
                {
                    b.HasOne("FollowMe.Domain.Entities.Carrinho", "Carrinho")
                        .WithMany("Items")
                        .HasForeignKey("CarrinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FollowMe.Domain.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("CodProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrinho");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.ItemPedido", b =>
                {
                    b.HasOne("FollowMe.Domain.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("CodProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FollowMe.Domain.Entities.Pedido", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("FollowMe.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FollowMe.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Carrinho", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("ItensPedido");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Carrinho");

                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
