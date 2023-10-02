﻿// <auto-generated />
using System;
using BibCorp.Persistence.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibCorp.Persistence.Migrations
{
    [DbContext(typeof(BibCorpContext))]
    [Migration("20230905185217_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("CapaUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Edicao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Editora")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmprestimoAcervoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmprestimoPatrimonioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ISBN")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatrimonioId")
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

                    b.HasIndex("PatrimonioId");

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

                    b.HasKey("AcervoId", "PatrimonioId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Patrimonios.Patrimonio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AcervoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Coluna")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataAtualizacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataIndisponibilidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("DetalheOrgiem")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmprestimoAcervoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmprestimoPatrimonioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ISBN")
                        .HasColumnType("TEXT");

                    b.Property<string>("Localizacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Origem")
                        .HasColumnType("TEXT");

                    b.Property<string>("Posicao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prateleira")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sala")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AcervoId");

                    b.HasIndex("ISBN");

                    b.HasIndex("EmprestimoAcervoId", "EmprestimoPatrimonioId");

                    b.ToTable("Patrimonios");
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Acervos.Acervo", b =>
                {
                    b.HasOne("BibCorp.Domain.Models.Emprestimos.Emprestimo", null)
                        .WithMany("Acervos")
                        .HasForeignKey("EmprestimoAcervoId", "EmprestimoPatrimonioId");
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

            modelBuilder.Entity("BibCorp.Domain.Models.Acervos.Acervo", b =>
                {
                    b.Navigation("Patrimonios");
                });

            modelBuilder.Entity("BibCorp.Domain.Models.Emprestimos.Emprestimo", b =>
                {
                    b.Navigation("Acervos");

                    b.Navigation("Patrimonios");
                });
#pragma warning restore 612, 618
        }
    }
}