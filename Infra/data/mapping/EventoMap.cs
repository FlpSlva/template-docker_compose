using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.data.mapping
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            //Tabela
            builder.ToTable("Eventos");

            //Chave Primária
            builder.HasKey(x => x.Id);

            //Propriedades
            builder.Property(x => x.Local)
                .IsRequired()
                .HasColumnName("Local")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.DataEvento)
                .IsRequired()
                .HasColumnName("DataEventos")
                .HasColumnType("datetime2");


            builder.Property(x => x.Tema)
                .IsRequired()
                .HasColumnName("Tema")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.QtdPessoas)
                .IsRequired()
                .HasColumnName("QtdPessoas")
                .HasColumnType("int");

            builder.Property(x => x.ImagemUrl)
                .IsRequired()
                .HasColumnName("ImagemUrl")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasColumnName("Telefone")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);


            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);


            //Indices
            builder.HasIndex(x => x.Tema, "IX_Evento_Tema")
                .IsUnique();
        }
    }
}
