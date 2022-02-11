using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GestaoInstituto.Infra.Data.Repositories
{
    public class UserAdministrationRepository : BaseRepository<UserAdministration, int>, IUserAdministrationRepository
    {
        private readonly GestaoContext _context;

        public UserAdministrationRepository(GestaoContext context) : base(context)
        {
            _context = context;
        }

        public List<UserAdministration> GetByUserId(int userId)
        {
            return _context.Set<UserAdministration>().Where(usp => usp.UsuarioId == userId).ToList();
        }
    }
}