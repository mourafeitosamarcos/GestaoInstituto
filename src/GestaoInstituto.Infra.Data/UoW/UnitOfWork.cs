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

        private IUserRepository _userRepository;
        private IInstitutionRepository _institutionRepository;
        private IAdministrationRepository _administrationRepository;
        private IPageRepository _pageRepository;   
        private IUserPageRepository _userPageRepository;
        private IUserAdministrationRepository _userAdministrationRepository;

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
