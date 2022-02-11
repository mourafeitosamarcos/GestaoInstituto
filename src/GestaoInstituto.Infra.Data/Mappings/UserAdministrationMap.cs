using GestaoInstituto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoInstituto.Infra.Data.Mappings
{
    internal class UserAdministrationMap : IEntityTypeConfiguration<UserAdministration>
    {
        public void Configure(EntityTypeBuilder<UserAdministration> builder)
        {
            builder.ToTable("TB_UsuarioAdministracao");

            builder.Property(c => c.Id).ValueGeneratedOnAdd()
                .HasColumnName("USUA_Id");

            builder.Property(c => c.UsuarioId)
                  .HasColumnName("USUA_USU_Id");

            builder.Property(c => c.AdministracaoId)
                 .HasColumnName("USUA_ADM_Id");
        }
    }
}
