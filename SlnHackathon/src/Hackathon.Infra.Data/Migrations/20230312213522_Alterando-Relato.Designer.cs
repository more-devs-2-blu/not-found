﻿// <auto-generated />
using System;
using Hackathon.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hackathon.Infra.Data.Migrations
{
    [DbContext(typeof(SQLServerContext))]
    [Migration("20230312213522_Alterando-Relato")]
    partial class AlterandoRelato
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hackathon.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Iluminação"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Segurança"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Transporte"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Vias"
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Relato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContadorLikes")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relatorio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Relatos");
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "anonimo@gmail.com",
                            Nome = "Anônimo",
                            Senha = "Anonimo"
                        },
                        new
                        {
                            Id = 2,
                            Email = "joao@gmail.com",
                            Nome = "João",
                            Senha = "Joao",
                            Telefone = "(47) 991456-5645"
                        },
                        new
                        {
                            Id = 3,
                            Email = "maria@gmail.com",
                            Nome = "Maria",
                            Senha = "Maria",
                            Telefone = "(47) 99115-5712"
                        },
                        new
                        {
                            Id = 4,
                            Email = "felipe@gmail.com",
                            Nome = "Felipe",
                            Senha = "Felipe",
                            Telefone = "(47) 99748-9632"
                        });
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Relato", b =>
                {
                    b.HasOne("Hackathon.Domain.Entities.Categoria", "Categoria")
                        .WithMany("RelatosList")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.Domain.Entities.Usuario", "Usuario")
                        .WithMany("RelatosList")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("RelatosList");
                });

            modelBuilder.Entity("Hackathon.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("RelatosList");
                });
#pragma warning restore 612, 618
        }
    }
}