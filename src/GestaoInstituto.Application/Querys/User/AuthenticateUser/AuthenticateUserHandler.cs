using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Querys.User.AuthenticateUser
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserQuery, OneOf<AuthenticateUserViewModel, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<AuthenticateUserViewModel, string>> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            AuthenticateUserViewModel authenticateUserViewModel = new AuthenticateUserViewModel();
            try
            {
                authenticateUserViewModel.User = _unitOfWork.UserRepository.IsAuthenticate(request.Email, request.Senha);

                if (authenticateUserViewModel.User == null) return "Usuário e/ou senha incorretos";

                return authenticateUserViewModel;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
