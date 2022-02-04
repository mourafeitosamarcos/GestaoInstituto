using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.Interfaces.Repositories;

namespace GestaoInstituto.Infra.Data.Repositories
{
    public class InstitutionRepository : BaseRepository<Institution, int>, IInstitutionRepository
    {
        private readonly GestaoContext _context;

        public InstitutionRepository(GestaoContext context) : base(context)
        {
            _context = context;
        }
    }
}
