using GestaoInstituto.Application.Model;
using GestaoInstituto.Application.Querys.User;
using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Handlers.User
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserQuery, OneOf<Domain.Entities.User, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<Domain.Entities.User, CustomErrors>> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            try
            {
                Domain.Entities.User usuario = _unitOfWork.UserRepository.IsAuthenticate(request.Email, request.Senha);

                if (usuario == null)
                {
                    customErrors.MessageError = "Usuário e/ou senha incorretos";
                    return customErrors;
                }

                return usuario;
            }
            catch (Exception ex)
            {
                customErrors.MessageError = ex.Message;
                return customErrors;
            }
        }
    }
}
