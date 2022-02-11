using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Commands.User.UpdateUser
{
    public class UpdateUserCommand : IRequest<OneOf<bool, string>>
    {
        public Domain.Entities.User User { get; set; }
    }
}
