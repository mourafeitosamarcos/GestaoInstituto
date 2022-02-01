using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UpdateUsuarioCommand : IRequest<Usuario>
    {
        public Usuario Usuario { get; set; }
    }
}
