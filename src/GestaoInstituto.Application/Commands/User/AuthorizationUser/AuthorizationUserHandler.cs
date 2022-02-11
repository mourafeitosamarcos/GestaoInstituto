using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Commands.User.AuthorizationUser
{
    internal class AuthorizationUserHandler : IRequestHandler<AuthorizationUserCommand, OneOf<bool, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorizationUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<bool, string>> Handle(AuthorizationUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<Domain.Entities.UserAdministration> userAdministrations = _unitOfWork.UserAdministrationRepository.GetByUserId(request.UserId);

                foreach (Domain.Entities.UserAdministration userAdministration in userAdministrations) _unitOfWork.UserAdministrationRepository.Delete(userAdministration.Id);

                foreach (int admId in request.AdministrationIds)
                    _unitOfWork.UserAdministrationRepository.Save(new Domain.Entities.UserAdministration
                    {
                        AdministracaoId = admId,
                        UsuarioId = request.UserId
                    });


                List<Domain.Entities.UserPage> userPages = _unitOfWork.UserPageRepository.GetByUserId(request.UserId);

                foreach (Domain.Entities.UserPage userPage in userPages) _unitOfWork.UserPageRepository.Delete(userPage.Id);

                foreach (int pagId in request.PageIds)
                    _unitOfWork.UserPageRepository.Save(new Domain.Entities.UserPage
                    {
                        PaginaId = pagId,
                        UsuarioId = request.UserId
                    });

                return true;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
