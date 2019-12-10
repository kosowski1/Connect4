﻿// <auto-generated />
using Connect4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace Connect4.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191125224849_1948")]
    partial class _1948
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Connect4.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("CEP");

                    b.Property<string>("CPF");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Endereco");

                    b.Property<int?>("JogadorId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<DateTime>("Nascimento");

                    b.Property<string>("Nome");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("JogadorId")
                        .IsUnique()
                        .HasFilter("[JogadorId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Connect4.Models.Jogador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("TorneioId");

                    b.HasKey("Id");

                    b.HasIndex("TorneioId");

                    b.ToTable("Jogador");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Jogador");
                });

            modelBuilder.Entity("Connect4.Models.Jogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Jogador1Id");

                    b.Property<int?>("Jogador2Id");

                    b.Property<int?>("JogadorPessoaId");

                    b.Property<int?>("TabuleiroId");

                    b.Property<int?>("TorneioId");

                    b.HasKey("Id");

                    b.HasIndex("Jogador1Id");

                    b.HasIndex("Jogador2Id");

                    b.HasIndex("JogadorPessoaId");

                    b.HasIndex("TabuleiroId");

                    b.HasIndex("TorneioId");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("Connect4.Models.Tabuleiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InternalData");

                    b.Property<int>("Turno");

                    b.HasKey("Id");

                    b.ToTable("Tabuleiros");
                });

            modelBuilder.Entity("Connect4.Models.Torneio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Dono");

                    b.Property<DateTime>("Inicio");

                    b.Property<string>("NomeTorneio");

                    b.Property<decimal>("Premiacao");

                    b.Property<int>("QuantidadeJogadores");

                    b.HasKey("Id");

                    b.ToTable("Torneio");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Connect4.Models.JogadorComputador", b =>
                {
                    b.HasBaseType("Connect4.Models.Jogador");

                    b.Property<string>("NomeComputador");

                    b.Property<string>("URLServico");

                    b.ToTable("JogadorComputador");

                    b.HasDiscriminator().HasValue("JogadorComputador");
                });

            modelBuilder.Entity("Connect4.Models.JogadorPessoa", b =>
                {
                    b.HasBaseType("Connect4.Models.Jogador");


                    b.ToTable("JogadorPessoa");

                    b.HasDiscriminator().HasValue("JogadorPessoa");
                });

            modelBuilder.Entity("Connect4.Models.ApplicationUser", b =>
                {
                    b.HasOne("Connect4.Models.JogadorPessoa", "Jogador")
                        .WithOne("Usuario")
                        .HasForeignKey("Connect4.Models.ApplicationUser", "JogadorId");
                });

            modelBuilder.Entity("Connect4.Models.Jogador", b =>
                {
                    b.HasOne("Connect4.Models.Torneio")
                        .WithMany("Jogadores")
                        .HasForeignKey("TorneioId");
                });

            modelBuilder.Entity("Connect4.Models.Jogo", b =>
                {
                    b.HasOne("Connect4.Models.Jogador", "Jogador1")
                        .WithMany()
                        .HasForeignKey("Jogador1Id");

                    b.HasOne("Connect4.Models.Jogador", "Jogador2")
                        .WithMany()
                        .HasForeignKey("Jogador2Id");

                    b.HasOne("Connect4.Models.JogadorPessoa")
                        .WithMany("Jogos")
                        .HasForeignKey("JogadorPessoaId");

                    b.HasOne("Connect4.Models.Tabuleiro", "Tabuleiro")
                        .WithMany()
                        .HasForeignKey("TabuleiroId");

                    b.HasOne("Connect4.Models.Torneio")
                        .WithMany("Jogos")
                        .HasForeignKey("TorneioId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Connect4.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Connect4.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Connect4.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Connect4.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
