using GestaoInstituto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Infra.Data.Mappings
{
    internal class AdministrationMap : IEntityTypeConfiguration<Administration>
    {
        public void Configure(EntityTypeBuilder<Administration> builder)
        {
            builder.ToTable("TB_Administracao");

            builder.Property(c => c.Id).ValueGeneratedOnAdd()
                .HasColumnName("ADM_Id");

            builder.Property(c => c.Nome)
                   .HasColumnName("ADM_Nome")
                   .HasMaxLength(150);

            builder.Property(c => c.DataInicio)
                  .HasColumnName("ADM_DataInicio");

            builder.Property(c => c.DataFim)
                  .HasColumnName("ADM_DataFim");

            builder.Property(c => c.Status)
                   .HasColumnName("ADM_Status");

            builder.Property(c => c.Excluido)
                   .HasColumnName("ADM_Excluido");
        }
    }
}
