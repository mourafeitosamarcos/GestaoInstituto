using GestaoInstituto.Application.Model;
using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Commands.Institution
{
    public class CreateInstitutionCommand : IRequest<OneOf<bool, CustomErrors>>
    {
        public Domain.Entities.Institution Institution { get; set; }
    }
}
