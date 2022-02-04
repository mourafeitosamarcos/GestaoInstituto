using GestaoInstituto.Application.Model;
using GestaoInstituto.Domain.Entities;
using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Querys.User
{
    public class AuthenticateUserQuery : IRequest<OneOf<Domain.Entities.User, CustomErrors>>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
