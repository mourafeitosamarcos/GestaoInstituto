using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Querys.User.ConsultUser
{
    public class ConsultUserHandler : IRequestHandler<ConsultUserQuery, OneOf<ConsultUserViewModel, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConsultUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<ConsultUserViewModel, string>> Handle(ConsultUserQuery request, CancellationToken cancellationToken)
        {
            ConsultUserViewModel consultUserViewModel = new ConsultUserViewModel();
            try
            {
                consultUserViewModel.User = _unitOfWork.UserRepository.GetById(request.Id);

                if (consultUserViewModel.User == null)
                    return "";

                consultUserViewModel.User.PaginaIds = _unitOfWork.UserPageRepository.GetByUserId(consultUserViewModel.User.Id).Select(us => us.PaginaId).ToList();
                consultUserViewModel.User.AdministracaoIds = _unitOfWork.UserAdministrationRepository.GetByUserId(consultUserViewModel.User.Id).Select(us => us.AdministracaoId).ToList();

                return consultUserViewModel;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
