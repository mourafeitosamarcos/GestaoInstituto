using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository UsuarioRepository { get; }

        Task<bool> SaveChangesAsync();
    }
}
