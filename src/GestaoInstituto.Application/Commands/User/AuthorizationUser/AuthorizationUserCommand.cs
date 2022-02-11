using MediatR;
using OneOf;
using System.Collections.Generic;

namespace GestaoInstituto.Application.Commands.User.AuthorizationUser
{
    public class AuthorizationUserCommand : IRequest<OneOf<bool, string>>
    {
        public int UserId { get; set; }
        public List<int> AdministrationIds { get; set; }
        public List<int> PageIds { get; set; }
    }
}
