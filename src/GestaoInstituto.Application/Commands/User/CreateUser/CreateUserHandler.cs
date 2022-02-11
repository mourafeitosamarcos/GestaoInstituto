using GestaoInstituto.Domain.Services;
using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Handlers.User.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, OneOf<bool, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OneOf<bool, string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            try
            {
                if (_unitOfWork.UserRepository.IsExist(request.User.Email)) return  "Usuário já Cadastrado";
               
                Domain.Entities.User usuario = new Domain.Entities.User();
                request.User.Senha = UserService.PasswordEncryption($"{request.User.Email}{request.User.Senha}");
                request.User.DataInclusao = DateTime.Now;

                usuario = _unitOfWork.UserRepository.Save(request.User);

                return true;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
