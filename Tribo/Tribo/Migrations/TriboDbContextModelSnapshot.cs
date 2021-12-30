﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tribo.Models;

#nullable disable

namespace Tribo.Migrations
{
    [DbContext(typeof(TriboDbContext))]
    partial class TriboDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tribo.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_Viagem")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.HasIndex("Id_Viagem")
                        .IsUnique();

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Tribo.Models.Contato", b =>
                {
                    b.Property<int>("IdContato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContato"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdContato");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("Tribo.Models.Imagem", b =>
                {
                    b.Property<int>("IdImg")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdImg"), 1L, 1);

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Dados")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PacoteIdPacote")
                        .HasColumnType("int");

                    b.HasKey("IdImg");

                    b.HasIndex("PacoteIdPacote");

                    b.ToTable("Imagem");
                });

            modelBuilder.Entity("Tribo.Models.Pacote", b =>
                {
                    b.Property<int>("IdPacote")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPacote"), 1L, 1);

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdImagem")
                        .HasColumnType("int");

                    b.Property<int>("IdTribo")
                        .HasColumnType("int");

                    b.Property<int?>("TriboParceiraIdTribo")
                        .HasColumnType("int");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPacote");

                    b.HasIndex("TriboParceiraIdTribo");

                    b.ToTable("Pacote");
                });

            modelBuilder.Entity("Tribo.Models.TriboParceira", b =>
                {
                    b.Property<int>("IdTribo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTribo"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeTribo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTribo");

                    b.ToTable("Tribo");
                });

            modelBuilder.Entity("Tribo.Models.Viagem", b =>
                {
                    b.Property<int>("IdViagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdViagem"), 1L, 1);

                    b.Property<DateTime>("DataIda")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVolta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdViagem");

                    b.ToTable("Viagem");
                });

            modelBuilder.Entity("Tribo.Models.Cliente", b =>
                {
                    b.HasOne("Tribo.Models.Viagem", "Viagem")
                        .WithOne("Cliente")
                        .HasForeignKey("Tribo.Models.Cliente", "Id_Viagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Viagem");
                });

            modelBuilder.Entity("Tribo.Models.Imagem", b =>
                {
                    b.HasOne("Tribo.Models.Pacote", null)
                        .WithMany("Imagens")
                        .HasForeignKey("PacoteIdPacote");
                });

            modelBuilder.Entity("Tribo.Models.Pacote", b =>
                {
                    b.HasOne("Tribo.Models.TriboParceira", "TriboParceira")
                        .WithMany()
                        .HasForeignKey("TriboParceiraIdTribo");

                    b.Navigation("TriboParceira");
                });

            modelBuilder.Entity("Tribo.Models.Pacote", b =>
                {
                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("Tribo.Models.Viagem", b =>
                {
                    b.Navigation("Cliente")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}