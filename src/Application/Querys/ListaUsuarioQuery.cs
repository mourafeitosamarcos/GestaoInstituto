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
    public class ListaUsuarioQuery : IRequest<OneOf<List<Usuario>, CustomErrors>>
    {
    }
}
