using GestaoInstituto.Domain.Interfaces.Repositories;
using GestaoInstituto.Domain.UoW;
using GestaoInstituto.Infra.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace GestaoInstituto.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestaoContext _context;

        public UnitOfWork(GestaoContext context)
        {
            _context = context;
        }
        private IUsuarioRepository _usuarioRepository;

        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                if (_usuarioRepository == null)
                {
                    _usuarioRepository = new UsuarioRepository(_context);
                }

                return _usuarioRepository;
            }
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
