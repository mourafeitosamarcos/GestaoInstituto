using GestaoInstituto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Infra.Data.Mappings
{
    public class PageMap : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.ToTable("TB_Pagina");

            builder.Property(c => c.Id).ValueGeneratedOnAdd()
                .HasColumnName("PAG_Id");

            builder.Property(c => c.PaiId)
                  .HasColumnName("PAG_PAG_Id");

            builder.Property(c => c.ModuloId)
                 .HasColumnName("PAG_MOD_Id");

            builder.Property(c => c.Nome)
                   .HasColumnName("PAG_Nome")
                   .HasMaxLength(80);

            builder.Property(c => c.Path)
                  .HasColumnName("PAG_Path")
                  .HasMaxLength(200);

            builder.Property(c => c.Icone)
                  .HasColumnName("PAG_Icone")
                  .HasMaxLength(100);

            builder.Property(c => c.Status)
                   .HasColumnName("PAG_Status");

            builder.Property(c => c.Ordem)
                   .HasColumnName("PAG_Menu_Ordem");

            builder.Property(c => c.Excluido)
                  .HasColumnName("PAG_Excluido");
        }
    }
}
