using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.Interfaces.Repositories;
using GestaoInstituto.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoInstituto.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        private readonly GestaoContext _context;

        public UserRepository(GestaoContext context) : base(context)
        {
            _context = context;
        }

        public User IsAuthenticate(string email, string senha)
        {
            return _context.Set<User>().Where(usu => usu.Email == email && usu.Senha == UserService.PasswordEncryption($"{email}{senha}")).FirstOrDefault();
        }

        public bool IsExist(string email)
        {
            return _context.Set<User>().Where(usu => usu.Email == email).Any();
        }
    }
}
