// <auto-generated />
using System;
using EasyMarket.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EasyMarket.Infra.Migrations
{
    [DbContext(typeof(EasyMarketContext))]
    [Migration("20220913041949_entradas3")]
    partial class entradas3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("EasyMarket.Domain.Entityes.EntradaItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("EntradasId")
                        .HasColumnType("integer");

                    b.Property<float>("PrecoCompra")
                        .HasColumnType("real");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EntradasId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("EntradaItems");
                });

            modelBuilder.Entity("EasyMarket.Domain.Entityes.Entradas", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasIdentityOptions(1L, null, null, null, null, null)
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChaveDeAcesso")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataNota")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("NumeroNota")
                        .HasColumnType("real");

                    b.Property<float>("ValorTotal")
                        .HasColumnType("real");

                    b.Property<int>("fornecedorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("EasyMarket.Domain.Entityes.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasIdentityOptions(1L, null, null, null, null, null)
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("nomeFantasia")
                        .HasColumnType("text");

                    b.Property<string>("razaoSocial")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("EasyMarket.Domain.Entityes.Produtos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasIdentityOptions(5L, null, null, null, null, null)
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Fabricante")
                        .HasColumnType("text");

                    b.Property<DateTime?>("dataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("descricao")
                        .HasColumnType("text");

                    b.Property<int>("estoque")
                        .HasColumnType("integer");

                    b.Property<float>("precoVenda")
                        .HasColumnType("real");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("EasyMarket.Domain.Entityes.Roles", b =>
                {
                    b.Property<int>("RolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.HasKey("RolesId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EasyMarket.Domain.Entityes.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Genero")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("RolesId")
                        .HasColumnType("integer");

                    b.Property<string>("cidade")
                        .HasColumnType("text");

                    b.Property<string>("cpf")
                        .HasColumnType("text");

                    b.Property<DateTime>("datanascimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("endereco")
                        .HasColumnType("text");

                    b.Property<string>("estado")
                        .HasColumnType("text");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.Property<int>("number")
                        .HasColumnType("integer");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RolesId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EasyMarket.Domain.Entityes.EntradaItems", b =>
                {
                    b.HasOne("EasyMarket.Domain.Entityes.Entradas", "entradas")
                        .WithMany("items")
                        .HasForeignKey("EntradasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyMarket.Domain.Entityes.Produtos", "produtos")
                        .WithMany("entradaItens")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("entradas");

                    b.Navigation("produtos");
                });

            modelBuilder.Entity("EasyMarket.Domain.Entityes.Users", b =>
                {
                    b.HasOne("EasyMarket.Domain.Entityes.Roles", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("EasyMarket.Domain.Entityes.Entradas", b =>
                {
                    b.Navigation("items");
                });

            modelBuilder.Entity("EasyMarket.Domain.Entityes.Produtos", b =>
                {
                    b.Navigation("entradaItens");
                });

            modelBuilder.Entity("EasyMarket.Domain.Entityes.Roles", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
