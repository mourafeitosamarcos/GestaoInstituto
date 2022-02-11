using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Handlers.Institution.CreateInstitution
{
    internal class CreateInstitutionHandler : IRequestHandler<CreateInstitutionCommand, OneOf<bool, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateInstitutionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<bool, string>> Handle(CreateInstitutionCommand request, CancellationToken cancellationToken)
        {            
            try
            {
                request.Institution.DataInclusao = DateTime.Now;

                _unitOfWork.InstitutionRepository.Save(request.Institution);

                return true;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
