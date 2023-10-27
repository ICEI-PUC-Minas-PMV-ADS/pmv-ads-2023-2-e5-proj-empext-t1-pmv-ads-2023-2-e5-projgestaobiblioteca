﻿// <auto-generated />
using System;
using BibCorp.Persistence.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibCorp.Persistence.Migrations
{
    [DbContext(typeof(BibCorpContext))]
    partial class BibCorpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("BibCorp.Domain.Models.Acervos.Acervo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnoPublicacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Autor")
                        .HasColumnType("TEXT");

                    b.Property<string>("CapaUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comentarios")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Edicao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Editora")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmprestimoAcervoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmprestimoPatrimonioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genero")
                        .HasColumnType("TEXT");

                    b.Property<string>("ISBN")
                        .HasColumnType("TEXT");

                    b.Property<int>("QtdPaginas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QtdeDisponivel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QtdeEmTransito")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QtdeEmprestada")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Resumo")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubTitulo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ISBN");

                    b.HasIndex("EmprestimoAcervoId", "EmprestimoPatrimonioId");

                    b.ToTable("Acervos");
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Emprestimos.Emprestimo", b =>
                {
                    b.Property<int>("AcervoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PatrimonioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataDevolucao")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataEmprestimo")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataPrevistaDevolucao")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Devolvido")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QtdeDiasAtraso")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QtdeDiasEmprestimo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AcervoId", "PatrimonioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Patrimonios.Patrimonio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AcervoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Coluna")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataAtualizacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataIndisponibilidade")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmprestimoAcervoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmprestimoPatrimonioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ISBN")
                        .HasColumnType("TEXT");

                    b.Property<string>("Localizacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Posicao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prateleira")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sala")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AcervoId");

                    b.HasIndex("ISBN");

                    b.HasIndex("EmprestimoAcervoId", "EmprestimoPatrimonioId");

                    b.ToTable("Patrimonios");
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Usuarios.Papel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeFuncao")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Usuarios.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Localizacao")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Usuarios.UsuarioPapel", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Acervos.Acervo", b =>
                {
                    b.HasOne("BibCorp.Domain.Models.Emprestimos.Emprestimo", null)
                        .WithMany("Acervos")
                        .HasForeignKey("EmprestimoAcervoId", "EmprestimoPatrimonioId");
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Emprestimos.Emprestimo", b =>
                {
                    b.HasOne("BibCorp.Domain.Models.Usuarios.Usuario", null)
                        .WithMany("Emprestimos")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Patrimonios.Patrimonio", b =>
                {
                    b.HasOne("BibCorp.Domain.Models.Acervos.Acervo", null)
                        .WithMany("Patrimonios")
                        .HasForeignKey("AcervoId");

                    b.HasOne("BibCorp.Domain.Models.Emprestimos.Emprestimo", null)
                        .WithMany("Patrimonios")
                        .HasForeignKey("EmprestimoAcervoId", "EmprestimoPatrimonioId");
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Usuarios.UsuarioPapel", b =>
                {
                    b.HasOne("BibCorp.Domain.Models.Usuarios.Papel", "Papel")
                        .WithMany("UsuariosPapeis")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibCorp.Domain.Models.Usuarios.Usuario", "Usuario")
                        .WithMany("UsuariosPapeis")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Papel");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("BibCorp.Domain.Models.Usuarios.Papel", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BibCorp.Domain.Models.Usuarios.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BibCorp.Domain.Models.Usuarios.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BibCorp.Domain.Models.Usuarios.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Acervos.Acervo", b =>
                {
                    b.Navigation("Patrimonios");
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Emprestimos.Emprestimo", b =>
                {
                    b.Navigation("Acervos");

                    b.Navigation("Patrimonios");
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Usuarios.Papel", b =>
                {
                    b.Navigation("UsuariosPapeis");
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Usuarios.Usuario", b =>
                {
                    b.Navigation("Emprestimos");

                    b.Navigation("UsuariosPapeis");
                });
#pragma warning restore 612, 618
        }
    }
}
