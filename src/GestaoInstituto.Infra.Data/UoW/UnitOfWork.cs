using GestaoInstituto.Domain.Interfaces.Repositories;
using GestaoInstituto.Domain.UoW;
using GestaoInstituto.Infra.Data.Repositories;

namespace GestaoInstituto.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestaoContext _context;

        public UnitOfWork(GestaoContext context)
        {
            _context = context;
        }

        private ICompanyRepository _companyRepository;
        private IInstitutionRepository _institutionRepository;
        private IUserRepository _userRepository;
        private IAdministrationRepository _administrationRepository;
        private IPageRepository _pageRepository;
        private IUserPageRepository _userPageRepository;
        private IUserAdministrationRepository _userAdministrationRepository;

        public ICompanyRepository CompanyRepository
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new CompanyRepository(_context);
                }

                return _companyRepository;
            }
        }
        public IInstitutionRepository InstitutionRepository
        {
            get
            {
                if (_institutionRepository == null)
                {
                    _institutionRepository = new InstitutionRepository(_context);
                }

                return _institutionRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }

                return _userRepository;
            }
        }


        public IAdministrationRepository AdministrationRepository
        {
            get
            {
                if (_administrationRepository == null)
                {
                    _administrationRepository = new AdministrationRepository(_context);
                }

                return _administrationRepository;
            }
        }

        public IPageRepository PageRepository
        {
            get
            {
                if (_pageRepository == null)
                {
                    _pageRepository = new PageRepository(_context);
                }

                return _pageRepository;
            }
        }

        public IUserPageRepository UserPageRepository
        {
            get
            {
                if (_userPageRepository == null)
                {
                    _userPageRepository = new UserPageRepository(_context);
                }

                return _userPageRepository;
            }
        }

        public IUserAdministrationRepository UserAdministrationRepository
        {
            get
            {
                if (_userAdministrationRepository == null)
                {
                    _userAdministrationRepository = new UserAdministrationRepository(_context);
                }

                return _userAdministrationRepository;
            }
        }
    }
}
