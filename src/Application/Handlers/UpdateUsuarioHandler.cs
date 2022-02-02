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
    internal class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioCommand, OneOf<bool, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUsuarioHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OneOf<bool, CustomErrors>> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
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
