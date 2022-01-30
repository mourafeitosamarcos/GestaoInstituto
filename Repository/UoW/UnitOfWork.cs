using Domain.Interfaces;
using Domain.UoW;
using Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.UoW
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
