
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
                if (_unitOfWork.UsuarioRepository.ExistLogin(request.Usuario.Email))
                {
                    customErrors.MessageError = "Usuário já Cadastrado";
                    return customErrors;
                }

                Usuario usuario = new Usuario();
                request.Usuario.Senha = UsuarioService.GerarSenha($"{request.Usuario.Email}{request.Usuario.Senha}");
                request.Usuario.DataInclusao = DateTime.Now;

                usuario = _unitOfWork.UsuarioRepository.Salvar(request.Usuario);

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
