using GestaoInstituto.Application.Commands.Institution;
using GestaoInstituto.Application.Model;
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
    internal class CreateInstitutionHandler : IRequestHandler<CreateInstitutionCommand, OneOf<bool, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateInstitutionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<bool, CustomErrors>> Handle(CreateInstitutionCommand request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            try
            {
                request.Institution.DataInclusao = DateTime.Now;

                _unitOfWork.InstitutionRepository.Update(request.Institution);

                return true;
            }
            catch (Exception ex)
            {
                customErrors.MessageError = ex.Message;
                return customErrors;
            }
        }
    }
}
