
using GestaoInstituto.Application.Commands.User;
using GestaoInstituto.Application.Model;
using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.Services;
using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Handlers.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, OneOf<bool, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OneOf<bool, CustomErrors>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            try
            {
                if (_unitOfWork.UserRepository.IsExist(request.User.Email))
                {
                    customErrors.MessageError = "Usuário já Cadastrado";
                    return customErrors;
                }

                Domain.Entities.User usuario = new Domain.Entities.User();
                request.User.Senha = UserService.PasswordEncryption($"{request.User.Email}{request.User.Senha}");
                request.User.DataInclusao = DateTime.Now;

                usuario = _unitOfWork.UserRepository.Save(request.User);

                return true;
            }
            catch (Exception ex)
            {
                customErrors.MessageError = ex.Message;
                return customErrors;
            }
            
        }
    }
}
