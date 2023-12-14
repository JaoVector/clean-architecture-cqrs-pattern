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
    [Migration("20231208194343_Migracao Criando Produto")]
    partial class MigracaoCriandoProduto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.HasKey("EnderecoId");

                    b.ToTable("Enderecos");
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

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CodPedido");

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

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CodProduto");

                    b.HasIndex("UsuarioId");

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

                    b.Property<Guid>("EnderecoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("FollowMe.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Produto", b =>
                {
                    b.HasOne("FollowMe.Domain.Entities.Usuario", null)
                        .WithMany("Produtos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("FollowMe.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("FollowMe.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
