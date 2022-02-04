using GestaoInstituto.Application.Model;
using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Querys.Institution
{
    public class ConsultInstitutionQuery : IRequest<OneOf<Domain.Entities.Institution, CustomErrors>>
    {
        public int Id { get; set; }
    }
}
