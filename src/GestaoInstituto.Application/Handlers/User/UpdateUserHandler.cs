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
            Usuario usuario = _unitOfWork.UsuarioRepository.GetById(request.Usuario.Id);
            try
            {
                usuario.Nome = request.Usuario.Nome;
                usuario.Email = request.Usuario.Email;
                usuario.NivelAcesso = request.Usuario.NivelAcesso;
                usuario.Status = request.Usuario.Status;

                if (!string.IsNullOrEmpty(usuario.Senha))
                    usuario.Senha = UsuarioService.GerarSenha($"{usuario.Email}{usuario.Senha}");

                usuario.DataAlteracao = DateTime.Now;
                usuario = _unitOfWork.UsuarioRepository.Atualizar(usuario);

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
