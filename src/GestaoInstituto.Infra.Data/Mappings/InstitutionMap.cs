using GestaoInstituto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Infra.Data.Mappings
{
    public class InstitutionMap : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.ToTable("TB_Instituicao");

            builder.Property(c => c.Id).ValueGeneratedOnAdd()
                .HasColumnName("INST_Id");

            builder.Property(c => c.AdministracaoId)
                 .HasColumnName("INST_ADM_Id");

            builder.Property(c => c.Nome)
                   .HasColumnName("INST_Nome")
                   .HasMaxLength(80);

            builder.Property(c => c.Email)
                  .HasColumnName("INST_Email")
                  .HasMaxLength(80);

            builder.Property(c => c.Status)
                   .HasColumnName("INST_Status")
                   .HasMaxLength(100);

            builder.Property(c => c.DataInclusao)
                   .HasColumnName("INST_DataInclusao");

            builder.Property(c => c.DataAlteracao)
                   .HasColumnName("INST_DataAlteracao");

            builder.Property(c => c.DataExclusao)
                  .HasColumnName("INST_DataExclusao");

            builder.Property(c => c.Excluido)
                 .HasColumnName("INST_Excluido");
        }
    }
}
