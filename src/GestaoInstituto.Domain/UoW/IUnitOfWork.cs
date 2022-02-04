using GestaoInstituto.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace GestaoInstituto.Domain.UoW
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IInstitutionRepository InstitutionRepository { get; }
        IAdministrationRepository AdministrationRepository { get; }
    }
}
