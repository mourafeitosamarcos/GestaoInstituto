using GestaoInstituto.Application.Model;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Application.Commands.Institution
{
    public class UpdateInstitutionCommand : IRequest<OneOf<bool, CustomErrors>>
    {
        public Domain.Entities.Institution Institution { get; set; }
    }
}
