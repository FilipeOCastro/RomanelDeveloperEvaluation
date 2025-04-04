﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Romanel.Evaluation.Infrastructure.Data;

#nullable disable

namespace Romanel.Evaluation.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250329115326_AddTipoCliente")]
    partial class AddTipoCliente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Romanel.Evaluation.Infrastructure.EventStore.StoredEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OccurredOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("StoredEvents");
                });

            modelBuilder.Entity("Romanel.Evaluation.domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("TipoCliente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Romanel.Evaluation.domain.Entities.Cliente", b =>
                {
                    b.OwnsOne("Romanel.Evaluation.domain.Entities.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("nvarchar(8)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("nvarchar(2)");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("Endereco")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
