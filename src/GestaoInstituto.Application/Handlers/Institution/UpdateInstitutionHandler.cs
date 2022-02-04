using GestaoInstituto.Application.Commands.Institution;
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
    public class UpdateInstitutionHandler : IRequestHandler<UpdateInstitutionCommand, OneOf<bool, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateInstitutionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<bool, CustomErrors>> Handle(UpdateInstitutionCommand request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            try
            {
                Domain.Entities.Institution institution = _unitOfWork.InstitutionRepository.GetById(request.Institution.Id);

                institution.Nome = request.Institution.Nome;
                institution.Email = request.Institution.Email;
                institution.Status = request.Institution.Status;
                institution.DataAlteracao = DateTime.Now;

                _unitOfWork.InstitutionRepository.Update(institution);

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
