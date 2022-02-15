﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pindorama.Data;

#nullable disable

namespace Pindorama.Migrations
{
    [DbContext(typeof(PindoramaDbContext))]
    [Migration("20220214195015_Pindoram")]
    partial class Pindoram
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArtesanatoCliente", b =>
                {
                    b.Property<int>("Artesanato")
                        .HasColumnType("int");

                    b.Property<int>("Cliente")
                        .HasColumnType("int");

                    b.HasKey("Artesanato", "Cliente");

                    b.HasIndex("Cliente");

                    b.ToTable("ArtesanatoCliente");
                });

            modelBuilder.Entity("ClientePacote", b =>
                {
                    b.Property<int>("Cliente")
                        .HasColumnType("int");

                    b.Property<int>("Pacote")
                        .HasColumnType("int");

                    b.HasKey("Cliente", "Pacote");

                    b.HasIndex("Pacote");

                    b.ToTable("ClientePacote");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Pindorama.Models.Admin", b =>
                {
                    b.Property<int>("IdAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAdmin"), 1L, 1);

                    b.Property<int?>("Id_AldeiaParceira")
                        .HasColumnType("int");

                    b.Property<int?>("Id_Cliente")
                        .HasColumnType("int");

                    b.Property<int?>("Id_Contato")
                        .HasColumnType("int");

                    b.Property<int?>("Id_Pacote")
                        .HasColumnType("int");

                    b.HasKey("IdAdmin");

                    b.HasIndex("Id_AldeiaParceira");

                    b.HasIndex("Id_Cliente");

                    b.HasIndex("Id_Contato");

                    b.HasIndex("Id_Pacote");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Pindorama.Models.AldeiaParceira", b =>
                {
                    b.Property<int>("IdAldeia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAldeia"), 1L, 1);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email_User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeAldeia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAldeia");

                    b.ToTable("AldeiaParceira");
                });

            modelBuilder.Entity("Pindorama.Models.Artesanato", b =>
                {
                    b.Property<int>("IdArtesanato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArtesanato"), 1L, 1);

                    b.Property<int?>("AldeiaParceira")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Id_Imagem")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdArtesanato");

                    b.HasIndex("AldeiaParceira");

                    b.HasIndex("Id_Imagem")
                        .IsUnique()
                        .HasFilter("[Id_Imagem] IS NOT NULL");

                    b.ToTable("Artesanato");
                });

            modelBuilder.Entity("Pindorama.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email_User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Pindorama.Models.Contato", b =>
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

            modelBuilder.Entity("Pindorama.Models.Imagem", b =>
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

                    b.HasKey("IdImg");

                    b.ToTable("Imagem");
                });

            modelBuilder.Entity("Pindorama.Models.Pacote", b =>
                {
                    b.Property<int>("IdPacote")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPacote"), 1L, 1);

                    b.Property<int?>("AldeiaParceira")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Id_Imagem")
                        .HasColumnType("int");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPacote");

                    b.HasIndex("AldeiaParceira");

                    b.HasIndex("Id_Imagem")
                        .IsUnique()
                        .HasFilter("[Id_Imagem] IS NOT NULL");

                    b.ToTable("Pacote");
                });

            modelBuilder.Entity("ArtesanatoCliente", b =>
                {
                    b.HasOne("Pindorama.Models.Cliente", null)
                        .WithMany()
                        .HasForeignKey("Artesanato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pindorama.Models.Artesanato", null)
                        .WithMany()
                        .HasForeignKey("Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClientePacote", b =>
                {
                    b.HasOne("Pindorama.Models.Pacote", null)
                        .WithMany()
                        .HasForeignKey("Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pindorama.Models.Cliente", null)
                        .WithMany()
                        .HasForeignKey("Pacote")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pindorama.Models.Admin", b =>
                {
                    b.HasOne("Pindorama.Models.AldeiaParceira", "AldeiaParceira")
                        .WithMany()
                        .HasForeignKey("Id_AldeiaParceira");

                    b.HasOne("Pindorama.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("Id_Cliente");

                    b.HasOne("Pindorama.Models.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("Id_Contato");

                    b.HasOne("Pindorama.Models.Pacote", "Pacote")
                        .WithMany()
                        .HasForeignKey("Id_Pacote");

                    b.Navigation("AldeiaParceira");

                    b.Navigation("Cliente");

                    b.Navigation("Contato");

                    b.Navigation("Pacote");
                });

            modelBuilder.Entity("Pindorama.Models.Artesanato", b =>
                {
                    b.HasOne("Pindorama.Models.AldeiaParceira", "Aldeia")
                        .WithMany("Artesanato")
                        .HasForeignKey("AldeiaParceira");

                    b.HasOne("Pindorama.Models.Imagem", "Imagem")
                        .WithOne("Artesanato")
                        .HasForeignKey("Pindorama.Models.Artesanato", "Id_Imagem");

                    b.Navigation("Aldeia");

                    b.Navigation("Imagem");
                });

            modelBuilder.Entity("Pindorama.Models.Pacote", b =>
                {
                    b.HasOne("Pindorama.Models.AldeiaParceira", "Aldeia")
                        .WithMany("Pacote")
                        .HasForeignKey("AldeiaParceira");

                    b.HasOne("Pindorama.Models.Imagem", "Imagem")
                        .WithOne("Pacote")
                        .HasForeignKey("Pindorama.Models.Pacote", "Id_Imagem");

                    b.Navigation("Aldeia");

                    b.Navigation("Imagem");
                });

            modelBuilder.Entity("Pindorama.Models.AldeiaParceira", b =>
                {
                    b.Navigation("Artesanato");

                    b.Navigation("Pacote");
                });

            modelBuilder.Entity("Pindorama.Models.Imagem", b =>
                {
                    b.Navigation("Artesanato")
                        .IsRequired();

                    b.Navigation("Pacote")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}