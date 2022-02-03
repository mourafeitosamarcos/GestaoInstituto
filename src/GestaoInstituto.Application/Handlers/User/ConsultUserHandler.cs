
using GestaoInstituto.Application.Model;
using GestaoInstituto.Application.Querys.User;
using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Handlers.User
{
    public class ConsultUserHandler : IRequestHandler<ConsultUserQuery, OneOf<Usuario, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConsultUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<Usuario, CustomErrors>> Handle(ConsultUserQuery request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            try
            {
                Usuario usuario =   _unitOfWork.UsuarioRepository.GetById(request.UsuarioId);

                return usuario;
            }
            catch (Exception ex)
            {
                customErrors.MessageError = ex.Message;
                return customErrors;
            }
        }
    }
}
