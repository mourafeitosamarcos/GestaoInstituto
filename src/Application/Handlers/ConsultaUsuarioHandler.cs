using Application.Model;
using Application.Querys;
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
    public class ConsultaUsuarioHandler : IRequestHandler<ConsultaUsuarioQuery, OneOf<Usuario, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConsultaUsuarioHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<Usuario, CustomErrors>> Handle(ConsultaUsuarioQuery request, CancellationToken cancellationToken)
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
