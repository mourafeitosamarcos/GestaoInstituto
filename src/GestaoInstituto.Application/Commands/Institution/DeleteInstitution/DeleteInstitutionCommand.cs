using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Commands.Institution.DeleteInstitution
{
    public class DeleteInstitutionCommand : IRequest<OneOf<bool, string>>
    {
        public int Id { get; set; }
    }
}
