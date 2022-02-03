using GestaoInstituto.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace GestaoInstituto.Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository UsuarioRepository { get; }

        Task<bool> SaveChangesAsync();
    }
}
