using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Commands.Institution.UpdateInstitutions
{
    public class UpdateInstitutionCommand : IRequest<OneOf<bool, string>>
    {
        public Domain.Entities.Institution Institution { get; set; }
    }
}
