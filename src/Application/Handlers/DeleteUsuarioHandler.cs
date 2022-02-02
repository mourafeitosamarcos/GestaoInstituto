using Application.Commands;
using Application.Model;
using Domain.Entity;
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
    public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioCommand, OneOf<bool, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUsuarioHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<bool, CustomErrors>> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            try
            {
                Usuario usuario = _unitOfWork.UsuarioRepository.GetById(request.Id);

                if(usuario == null)
                {
                    customErrors.MessageError = "Usuário não encontrado!";
                    return customErrors;
                }

                _unitOfWork.UsuarioRepository.Deletar(usuario.Id);

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
