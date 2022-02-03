using GestaoInstituto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Infra.Data.Mappings
{
    internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_Usuario");

            builder.Property(c => c.Id).ValueGeneratedOnAdd()
                .HasColumnName("USUA_Id");
            // .IsRequired();


            builder.Property(c => c.InstituicaoId)
                   .HasColumnName("USUA_INST_Id");
            //.IsRequired();

            builder.Property(c => c.Nome)
                   .HasColumnName("USUA_Nome")
                   .HasMaxLength(100);
            ///.IsRequired();

            builder.Property(c => c.Email)
                   .HasColumnName("USUA_Email")
                   .HasMaxLength(100);
            // .IsRequired();


            builder.Property(c => c.Senha)
                   .HasColumnName("USUA_Senha")
                   .HasMaxLength(100);
            // .IsRequired();


            builder.Property(c => c.NivelAcesso)
                   .HasColumnName("USUA_Nivel")
                   .HasMaxLength(100);
            // .IsRequired();


            builder.Property(c => c.Status)
                   .HasColumnName("USUA_Status")
                   .HasMaxLength(100);
            // .IsRequired();

            builder.Property(c => c.DataInclusao)
                   .HasColumnName("USUA_DataInclusao");

            builder.Property(c => c.DataAlteracao)
                   .HasColumnName("USUA_DataAlteracao");

            builder.Property(c => c.DataExclusao)
                  .HasColumnName("USUA_DataExclusao");

            builder.Property(c => c.Excluido)
                 .HasColumnName("USUA_Excluido");
        }
    }
}
