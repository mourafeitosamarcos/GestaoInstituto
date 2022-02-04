using GestaoInstituto.Application.Model;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Application.Querys.Administration
{
    public class ListAdministrationQuery : IRequest<OneOf<List<Domain.Entities.Administration>, CustomErrors>>
    {
    }
}
