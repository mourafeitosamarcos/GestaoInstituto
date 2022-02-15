using GestaoInstituto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Infra.Data.Mappings
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("TB_Empresa");

            builder.Property(c => c.Id).ValueGeneratedOnAdd()
                .HasColumnName("EMP_Id");

            builder.Property(c => c.Nome)
                   .HasColumnName("EMP_Nome")
                   .HasMaxLength(80);

            builder.Property(c => c.NomeContatoResponsavel)
                  .HasColumnName("EMP_NomeContatoResponsavel")
                  .HasMaxLength(80);

            builder.Property(c => c.Telefone)
                  .HasColumnName("EMP_Telefone")
                  .HasMaxLength(50);

            builder.Property(c => c.Email)
                   .HasColumnName("EMP_Email")
                   .HasMaxLength(100);

            builder.Property(c => c.QauntidadePessoas)
                   .HasColumnName("EMP_QauntidadePessoas");

            builder.Property(c => c.DataCadastro)
                   .HasColumnName("EMP_DataCadastro");

            builder.Property(c => c.DataAtivacao)
                   .HasColumnName("EMP_DataAtivacao");

            builder.Property(c => c.DataInativacao)
                   .HasColumnName("EMP_DataInativacao");

            builder.Property(c => c.Status)
                  .HasColumnName("EMP_Status");
        }
    }
}
