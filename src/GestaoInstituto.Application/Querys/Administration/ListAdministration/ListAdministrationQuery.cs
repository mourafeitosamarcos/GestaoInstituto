using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Querys.Administration.ListAdministration
{
    public class ListAdministrationQuery : IRequest<OneOf<ListAdministrationViewModel, string>>
    {
        
    }
}
