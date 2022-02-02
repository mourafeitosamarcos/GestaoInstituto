using Application.Model;
using Domain.Entity;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UpdateUsuarioCommand : IRequest<OneOf<bool, CustomErrors>>
    {
        public Usuario Usuario { get; set; }
    }
}
