using GestaoInstituto.Application.Model;
using GestaoInstituto.Application.Querys.Institution;
using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Handlers.Institution
{
    public class ConsultInstitutionHandler : IRequestHandler<ConsultInstitutionQuery, OneOf<Domain.Entities.Institution, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConsultInstitutionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OneOf<Domain.Entities.Institution, CustomErrors>> Handle(ConsultInstitutionQuery request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            try
            {
                Domain.Entities.Institution institution = _unitOfWork.InstitutionRepository.GetById(request.Id);

                if (institution == null)
                {
                    customErrors.MessageError = "Registro não encontrado!";
                    return customErrors;
                }

                return institution;
            }
            catch (Exception ex)
            {
                customErrors.MessageError = ex.Message;
                return customErrors;
            }
        }
    }
}
