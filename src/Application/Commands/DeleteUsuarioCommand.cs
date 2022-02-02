using Application.Model;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteUsuarioCommand : IRequest<OneOf<bool, CustomErrors>>
    {
        public int Id { get; set; }
    }
}
