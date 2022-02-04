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
    internal class UpdateUserHandler : IRequestHandler<UpdateUserCommand, OneOf<bool, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OneOf<bool, CustomErrors>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            Domain.Entities.User usuario = _unitOfWork.UserRepository.GetById(request.User.Id);
            try
            {
                usuario.Nome = request.User.Nome;
                usuario.Email = request.User.Email;
                usuario.NivelAcesso = request.User.NivelAcesso;
                usuario.Status = request.User.Status;

                if (!string.IsNullOrEmpty(usuario.Senha))
                    usuario.Senha = UserService.PasswordEncryption($"{usuario.Email}{usuario.Senha}");

                usuario.DataAlteracao = DateTime.Now;
                usuario = _unitOfWork.UserRepository.Update(usuario);

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
