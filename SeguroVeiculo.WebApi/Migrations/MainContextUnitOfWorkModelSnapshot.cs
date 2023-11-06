﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeguroVeiculo.Infra.Repository;

#nullable disable

namespace SeguroVeiculo.WebApi.Migrations
{
    [DbContext(typeof(MainContextUnitOfWork))]
    partial class MainContextUnitOfWorkModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SeguroVeiculo.Domain.Aggs.SeguradoAgg.Segurado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Segurado");
                });

            modelBuilder.Entity("SeguroVeiculo.Domain.Aggs.SeguroAgg.Seguro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FimVigencia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InicioVigencia")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeguradoId")
                        .HasColumnType("int");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeguradoId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Seguro");
                });

            modelBuilder.Entity("SeguroVeiculo.Domain.Aggs.VeiculoAgg.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("SeguroVeiculo.Domain.Aggs.SeguroAgg.Seguro", b =>
                {
                    b.HasOne("SeguroVeiculo.Domain.Aggs.SeguradoAgg.Segurado", "Segurado")
                        .WithMany("Seguros")
                        .HasForeignKey("SeguradoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeguroVeiculo.Domain.Aggs.VeiculoAgg.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Segurado");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("SeguroVeiculo.Domain.Aggs.SeguradoAgg.Segurado", b =>
                {
                    b.Navigation("Seguros");
                });
#pragma warning restore 612, 618
        }
    }
}