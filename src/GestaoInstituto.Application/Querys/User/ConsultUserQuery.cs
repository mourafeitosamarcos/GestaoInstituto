using GestaoInstituto.Application.Model;
using GestaoInstituto.Domain.Entities;
using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Querys.User
{
    public class ConsultUserQuery : IRequest<OneOf<Domain.Entities.User, CustomErrors>>
    {
        public int Id { get; set; }
    }
}
