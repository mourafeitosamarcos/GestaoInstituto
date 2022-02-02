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
    public class ListaUsuarioHandler : IRequestHandler<ListaUsuarioQuery, OneOf<List<Usuario>, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListaUsuarioHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<List<Usuario>, CustomErrors>> Handle(ListaUsuarioQuery request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            try
            {
                List<Usuario> usuarios = _unitOfWork.UsuarioRepository.GetAll().ToList();
                return usuarios;
            }
            catch (Exception ex)
            {
                customErrors.MessageError = ex.Message;
                return customErrors;
            }
            
        }
    }
}
