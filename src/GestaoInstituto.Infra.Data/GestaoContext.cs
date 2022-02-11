using GestaoInstituto.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GestaoInstituto.Infra.Data
{
    public class GestaoContext : DbContext
    {
        public GestaoContext(DbContextOptions<GestaoContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new InstitutionMap());
            modelBuilder.ApplyConfiguration(new AdministrationMap());
            modelBuilder.ApplyConfiguration(new PageMap());
            modelBuilder.ApplyConfiguration(new UserPageMap());
            modelBuilder.ApplyConfiguration(new UserAdministrationMap());
        }

    }
}
