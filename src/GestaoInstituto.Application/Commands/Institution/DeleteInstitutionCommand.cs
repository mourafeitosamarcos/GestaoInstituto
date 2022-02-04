using GestaoInstituto.Application.Model;
using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Commands.Institution
{
    public class DeleteInstitutionCommand : IRequest<OneOf<bool, CustomErrors>>
    {
        public int Id { get; set; }
    }
}
