using MediatR;
using OneOf;
using System.Collections.Generic;

namespace GestaoInstituto.Application.Querys.User.ListUser
{
    public class ListUserQuery : IRequest<OneOf<ListUserViewModel, string>>
    {
    }
}
