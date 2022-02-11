using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Commands.Institution.DeleteInstitution
{
    internal class DeleteInstitutionHandler : IRequestHandler<DeleteInstitutionCommand, OneOf<bool, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteInstitutionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<bool, string>> Handle(DeleteInstitutionCommand request, CancellationToken cancellationToken)
        {

            try
            {
                Domain.Entities.Institution institution = _unitOfWork.InstitutionRepository.GetById(request.Id);

                if (institution == null)
                {
                   return "Registro não encontrado!";
                }

                institution.DataExclusao = DateTime.Now;
                institution.Excluido = true;

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
