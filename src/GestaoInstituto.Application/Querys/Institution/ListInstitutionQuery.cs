using GestaoInstituto.Application.Model;
using MediatR;
using OneOf;
using System.Collections.Generic;

namespace GestaoInstituto.Application.Querys.Institution
{
    public class ListInstitutionQuery : IRequest<OneOf<List<Domain.Entities.Institution>, CustomErrors>>
    {
    }
}
