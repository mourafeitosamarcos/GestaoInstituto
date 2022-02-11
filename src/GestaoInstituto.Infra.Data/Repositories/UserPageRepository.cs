using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GestaoInstituto.Infra.Data.Repositories
{
    public class UserPageRepository : BaseRepository<UserPage, int>, IUserPageRepository
    {
        private readonly GestaoContext _context;

        public UserPageRepository(GestaoContext context) : base(context)
        {
            _context = context;
        }

        public List<UserPage> GetByUserId(int userId)
        {
            return _context.Set<UserPage>().Where(usp => usp.UsuarioId == userId).ToList();
        }
    }
}
