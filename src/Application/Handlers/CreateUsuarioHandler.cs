using Application.Commands;
using Application.Model;
using Domain.Entity;
using Domain.Service;
using Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, OneOf<bool, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUsuarioHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OneOf<bool, CustomErrors>> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
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
