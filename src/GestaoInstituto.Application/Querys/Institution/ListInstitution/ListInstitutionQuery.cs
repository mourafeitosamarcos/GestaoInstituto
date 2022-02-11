using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Querys.Institution.ListInstitution
{
    public class ListInstitutionQuery : IRequest<OneOf<ListInstitutionViewModel, string>>
    {
    }
}
