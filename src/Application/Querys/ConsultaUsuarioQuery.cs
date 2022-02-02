using Application.Model;
using Domain.Entity;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Querys
{
    public class ConsultaUsuarioQuery : IRequest<OneOf<Usuario, CustomErrors>>
    {
        public int UsuarioId { get; set; }
    }
}
