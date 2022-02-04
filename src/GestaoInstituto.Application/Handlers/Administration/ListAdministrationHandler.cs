using GestaoInstituto.Application.Model;
using GestaoInstituto.Application.Querys.Administration;
using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Handlers.Administration
{
    internal class ListAdministrationHandler : IRequestHandler<ListAdministrationQuery, OneOf<List<Domain.Entities.Administration>, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListAdministrationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<List<Domain.Entities.Administration>, CustomErrors>> Handle(ListAdministrationQuery request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            try
            {
                List<Domain.Entities.Administration> administrations = _unitOfWork.AdministrationRepository.GetAll().ToList();

                return administrations;
            }
            catch (Exception ex)
            {
                customErrors.MessageError = ex.Message;
                return customErrors;
            }
        }
    }
}
