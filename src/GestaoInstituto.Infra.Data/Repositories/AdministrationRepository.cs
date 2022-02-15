using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.Interfaces.Repositories;

namespace GestaoInstituto.Infra.Data.Repositories
{
    public class AdministrationRepository : BaseRepository<Administration, int>, IAdministrationRepository
    {
        private readonly GestaoContext _context;

        public AdministrationRepository(GestaoContext context) : base(context)
        {
            _context = context;
        }
    }
}
