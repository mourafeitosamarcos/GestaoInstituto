using GestaoInstituto.Domain.Services;
using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Commands.User.UpdateUser
{
    internal class UpdateUserHandler : IRequestHandler<UpdateUserCommand, OneOf<bool, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OneOf<bool, string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            Domain.Entities.User usuario = _unitOfWork.UserRepository.GetById(request.User.Id);
            try
            {
                usuario.Nome = request.User.Nome;
                usuario.Email = request.User.Email;
                usuario.NivelAcesso = request.User.NivelAcesso;
                usuario.Status = request.User.Status;

                if (!string.IsNullOrEmpty(request.User.Senha))
                    usuario.Senha = UserService.PasswordEncryption($"{request.User.Email}{request.User.Senha}");

                usuario.DataAlteracao = DateTime.Now;
                usuario = _unitOfWork.UserRepository.Update(usuario);

                return true;    
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
