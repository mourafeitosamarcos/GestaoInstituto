using GestaoInstituto.Application.Model;
using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Commands.User
{
    public class DeleteUserCommand : IRequest<OneOf<bool, CustomErrors>>
    {
        public int Id { get; set; }
    }
}
