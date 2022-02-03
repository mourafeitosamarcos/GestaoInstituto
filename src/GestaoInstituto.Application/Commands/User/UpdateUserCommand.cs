using GestaoInstituto.Application.Model;
using GestaoInstituto.Domain.Entities;
using MediatR;
using OneOf;

namespace GestaoInstituto.Application.Commands.User
{
    public class UpdateUserCommand : IRequest<OneOf<bool, CustomErrors>>
    {
        public Usuario Usuario { get; set; }
    }
}
