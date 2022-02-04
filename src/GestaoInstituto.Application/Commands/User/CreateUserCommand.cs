using GestaoInstituto.Application.Model;
using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Commands.User
{
    public class CreateUserCommand : IRequest<OneOf<bool, CustomErrors>>
    {
        public Domain.Entities.User User { get; set; }
    }
}
