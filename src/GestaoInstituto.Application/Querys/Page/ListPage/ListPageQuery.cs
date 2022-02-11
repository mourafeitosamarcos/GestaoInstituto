using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Application.Querys.Page.ListPage
{
    public class ListPageQuery : IRequest<OneOf<ListPageViewModel, string>>
    {
    }
}
