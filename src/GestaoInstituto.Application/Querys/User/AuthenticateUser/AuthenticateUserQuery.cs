using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Querys.User.AuthenticateUser
{
    public class AuthenticateUserQuery : IRequest<OneOf<AuthenticateUserViewModel, string>>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
