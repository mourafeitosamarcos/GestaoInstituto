using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Handlers.Institution.CreateInstitution
{
    public class CreateInstitutionCommand : IRequest<OneOf<bool, string>>
    {
        public Domain.Entities.Institution Institution { get; set; }
    }
}
