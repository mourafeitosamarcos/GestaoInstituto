using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Querys.Institution.ConsultInstitutionQuery
{
    public class ConsultInstitutionQuery : IRequest<OneOf<ConsultInstitutionViewModel, string>>
    {
        public int Id { get; set; }
    }
}
