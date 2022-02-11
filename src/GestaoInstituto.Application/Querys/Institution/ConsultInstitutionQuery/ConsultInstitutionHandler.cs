using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Querys.Institution.ConsultInstitutionQuery
{
    public class ConsultInstitutionHandler : IRequestHandler<ConsultInstitutionQuery, OneOf<ConsultInstitutionViewModel, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConsultInstitutionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OneOf<ConsultInstitutionViewModel, string>> Handle(ConsultInstitutionQuery request, CancellationToken cancellationToken)
        {
            ConsultInstitutionViewModel consultInstitutionViewModel = new ConsultInstitutionViewModel();
            try
            {
                consultInstitutionViewModel.Institution = _unitOfWork.InstitutionRepository.GetById(request.Id);

                if (consultInstitutionViewModel.Institution == null) return "Registro não encontrado!";
                

                return consultInstitutionViewModel;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
