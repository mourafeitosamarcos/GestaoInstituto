using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoInstituto.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario, int>, IUsuarioRepository
    {
        private readonly GestaoContext _context;

        public UsuarioRepository(GestaoContext context) : base(context)
        {
            _context = context;
        }

        public bool ExistLogin(string email)
        {
            return _context.Set<Usuario>().Where(usu => usu.Email == email).Any();
        }
    }
}
