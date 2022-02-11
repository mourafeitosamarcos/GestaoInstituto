using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Handlers.User.CreateUser
{
    public class CreateUserCommand : IRequest<OneOf<bool, string>>
    {
        public Domain.Entities.User User { get; set; }
    }
}
