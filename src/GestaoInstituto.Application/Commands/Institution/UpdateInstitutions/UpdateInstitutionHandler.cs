using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Commands.Institution.UpdateInstitutions
{
    public class UpdateInstitutionHandler : IRequestHandler<UpdateInstitutionCommand, OneOf<bool, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateInstitutionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<bool, string>> Handle(UpdateInstitutionCommand request, CancellationToken cancellationToken)
        {

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
                return ex.Message;
            }
        }
    }
}
