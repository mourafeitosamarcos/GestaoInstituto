using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Commands.User.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, OneOf<bool, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<bool, string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            try
            {
                Domain.Entities.User usuario = _unitOfWork.UserRepository.GetById(request.Id);

                if(usuario == null) return "Usuário não encontrado!";
             
                usuario.DataExclusao = DateTime.Now;
                usuario.Excluido = true;

                _unitOfWork.UserRepository.Update(usuario);

                return true;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
