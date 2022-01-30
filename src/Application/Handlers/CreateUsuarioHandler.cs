using Application.Commands;
using Domain.Entity;
using Domain.UoW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, Usuario>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUsuarioHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Usuario> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            Usuario usuario = new Usuario();
            try
            {
                usuario.DataInclusao = DateTime.Now;
                usuario = _unitOfWork.UsuarioRepository.Salvar(request.Usuario);
            }
            catch (Exception ex)
            {
                var rrr = ex;
            }
            return usuario;
        }
    }
}
