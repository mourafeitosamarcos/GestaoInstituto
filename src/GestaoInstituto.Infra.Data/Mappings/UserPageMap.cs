using GestaoInstituto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoInstituto.Infra.Data.Mappings
{
    internal class UserPageMap : IEntityTypeConfiguration<UserPage>
    {
        public void Configure(EntityTypeBuilder<UserPage> builder)
        {
            builder.ToTable("TB_UsuarioPagina");

            builder.Property(c => c.Id).ValueGeneratedOnAdd()
                .HasColumnName("USUP_Id");

            builder.Property(c => c.UsuarioId)
                  .HasColumnName("USUP_USU_Id");

            builder.Property(c => c.PaginaId)
                 .HasColumnName("USUP_PAG_Id");
        }
    }
}