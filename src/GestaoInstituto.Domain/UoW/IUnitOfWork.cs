using GestaoInstituto.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace GestaoInstituto.Domain.UoW
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; }
        IInstitutionRepository InstitutionRepository { get; }
        IUserRepository UserRepository { get; }
        IAdministrationRepository AdministrationRepository { get; }
        IPageRepository PageRepository { get; }
        IUserPageRepository UserPageRepository { get; }
        IUserAdministrationRepository UserAdministrationRepository { get; }
    }
}
