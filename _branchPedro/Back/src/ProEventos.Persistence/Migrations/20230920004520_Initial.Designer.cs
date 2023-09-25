﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProEventos.Persistence.Contextos;

namespace ProEventos.Persistence.Migrations
{
    [DbContext(typeof(ProEventosContext))]
    [Migration("20230920004520_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ProEventos.Domain.Biblioteca.Acervo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("AnoPublicacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Capa")
                        .HasColumnType("TEXT");

                    b.Property<string>("Categoria")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ISBN")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PatrimonioId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("QuantidadeAlocada")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("QuantidadeDisponivel")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("QuantidadeTransito")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Resumo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subtitulo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatrimonioId");

                    b.ToTable("Acervos");
                });

            modelBuilder.Entity("ProEventos.Domain.Biblioteca.Emprestimo", b =>
                {
                    b.Property<int?>("PatrimonioId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AcervoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataEmprestimo")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Devolvido")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DiasAlocacao")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DiasAtraso")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("PatrimonioId", "UsuarioId");

                    b.HasIndex("AcervoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("ProEventos.Domain.Biblioteca.Patrimonio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Cadastro")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Coluna")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ISBN")
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Posicao")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Prateleira")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Sala")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Patrimonios");
                });

            modelBuilder.Entity("ProEventos.Domain.Biblioteca.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Localizacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProEventos.Domain.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataEvento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .HasColumnType("TEXT");

                    b.Property<int>("QtdPessoas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tema")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("ProEventos.Domain.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Preco")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("ProEventos.Domain.Palestrante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiniCurriculo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Palestrantes");
                });

            modelBuilder.Entity("ProEventos.Domain.PalestranteEvento", b =>
                {
                    b.Property<int>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PalestranteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventoId", "PalestranteId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("PalestrantesEventos");
                });

            modelBuilder.Entity("ProEventos.Domain.RedeSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PalestranteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("RedesSociais");
                });

            modelBuilder.Entity("ProEventos.Domain.Biblioteca.Acervo", b =>
                {
                    b.HasOne("ProEventos.Domain.Biblioteca.Patrimonio", "Patrimonio")
                        .WithMany()
                        .HasForeignKey("PatrimonioId");

                    b.Navigation("Patrimonio");
                });

            modelBuilder.Entity("ProEventos.Domain.Biblioteca.Emprestimo", b =>
                {
                    b.HasOne("ProEventos.Domain.Biblioteca.Acervo", "Acervo")
                        .WithMany()
                        .HasForeignKey("AcervoId");

                    b.HasOne("ProEventos.Domain.Biblioteca.Patrimonio", "Patrimonio")
                        .WithMany("Emprestimos")
                        .HasForeignKey("PatrimonioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProEventos.Domain.Biblioteca.Usuario", "Usuario")
                        .WithMany("Emprestimos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acervo");

                    b.Navigation("Patrimonio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProEventos.Domain.Lote", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "Evento")
                        .WithMany("Lotes")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("ProEventos.Domain.PalestranteEvento", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "Evento")
                        .WithMany("PalestrantesEventos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProEventos.Domain.Palestrante", "Palestrante")
                        .WithMany("PalestrantesEventos")
                        .HasForeignKey("PalestranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Palestrante");
                });

            modelBuilder.Entity("ProEventos.Domain.RedeSocial", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "Evento")
                        .WithMany("RedesSociais")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProEventos.Domain.Palestrante", "Palestrante")
                        .WithMany("RedesSociais")
                        .HasForeignKey("PalestranteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Evento");

                    b.Navigation("Palestrante");
                });

            modelBuilder.Entity("ProEventos.Domain.Biblioteca.Patrimonio", b =>
                {
                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("ProEventos.Domain.Biblioteca.Usuario", b =>
                {
                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("ProEventos.Domain.Evento", b =>
                {
                    b.Navigation("Lotes");

                    b.Navigation("PalestrantesEventos");

                    b.Navigation("RedesSociais");
                });

            modelBuilder.Entity("ProEventos.Domain.Palestrante", b =>
                {
                    b.Navigation("PalestrantesEventos");

                    b.Navigation("RedesSociais");
                });
#pragma warning restore 612, 618
        }
    }
}
