using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Querys.User.ConsultUser
{
    public class ConsultUserQuery : IRequest<OneOf<ConsultUserViewModel, string>>
    {
        public int Id { get; set; }
    }
}
