using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Commands.User.DeleteUser
{
    public class DeleteUserCommand : IRequest<OneOf<bool, string>>
    {
        public int Id { get; set; }
    }
}
