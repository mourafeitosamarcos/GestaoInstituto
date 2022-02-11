using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Querys.Institution.ListInstitution
{
    public class ListInstitutionHandler : IRequestHandler<ListInstitutionQuery, OneOf<ListInstitutionViewModel, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListInstitutionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OneOf<ListInstitutionViewModel, string>> Handle(ListInstitutionQuery request, CancellationToken cancellationToken)
        {
            ListInstitutionViewModel listInstitutionViewModel = new ListInstitutionViewModel();
            try
            {
                listInstitutionViewModel.Institutions = _unitOfWork.InstitutionRepository.GetAll().ToList();

                return listInstitutionViewModel;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
