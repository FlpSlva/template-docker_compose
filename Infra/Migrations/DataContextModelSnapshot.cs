﻿// <auto-generated />
using System;
using Infra.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.entities.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataEvento")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("DataEventos");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Email");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("ImagemUrl");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Local");

                    b.Property<int>("QtdPessoas")
                        .HasColumnType("int")
                        .HasColumnName("QtdPessoas");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Telefone");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Tema");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Tema" }, "IX_Evento_Tema")
                        .IsUnique();

                    b.ToTable("Eventos", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
