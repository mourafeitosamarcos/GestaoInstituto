using GestaoInstituto.Application.Model;
using GestaoInstituto.Domain.Entities;
using MediatR;
using OneOf;
using System.Collections.Generic;

namespace GestaoInstituto.Application.Querys.User
{
    public class ListUserQuery : IRequest<OneOf<List<Domain.Entities.User>, CustomErrors>>
    {
    }
}
