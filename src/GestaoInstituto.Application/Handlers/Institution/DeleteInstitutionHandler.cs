using GestaoInstituto.Application.Commands.Institution;
using GestaoInstituto.Application.Model;
using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Handlers.Institution
{
    internal class DeleteInstitutionHandler : IRequestHandler<DeleteInstitutionCommand, OneOf<bool, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteInstitutionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<bool, CustomErrors>> Handle(DeleteInstitutionCommand request, CancellationToken cancellationToken)
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

                institution.DataExclusao = DateTime.Now;
                institution.Excluido = true;

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
