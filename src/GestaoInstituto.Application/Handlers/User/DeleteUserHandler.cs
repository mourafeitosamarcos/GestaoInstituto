
using GestaoInstituto.Application.Commands.User;
using GestaoInstituto.Application.Model;
using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Handlers.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, OneOf<bool, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<bool, CustomErrors>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            try
            {
                Domain.Entities.User usuario = _unitOfWork.UserRepository.GetById(request.Id);

                if(usuario == null)
                {
                    customErrors.MessageError = "Usuário não encontrado!";
                    return customErrors;
                }

                usuario.DataExclusao = DateTime.Now;
                usuario.Excluido = true;

                _unitOfWork.UserRepository.Update(usuario);

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
