using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.Interfaces.Repositories;

namespace GestaoInstituto.Infra.Data.Repositories
{
    public class CompanyRepository : BaseRepository<Company, int>, ICompanyRepository
    {
        private readonly GestaoContext _context;

        public CompanyRepository(GestaoContext context) : base(context)
        {
            _context = context;
        }
    }
}
