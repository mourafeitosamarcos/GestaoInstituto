using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Querys.Administration.ListAdministration
{
    internal class ListAdministrationHandler : IRequestHandler<ListAdministrationQuery, OneOf<ListAdministrationViewModel, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListAdministrationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<ListAdministrationViewModel, string>> Handle(ListAdministrationQuery request, CancellationToken cancellationToken)
        {
            ListAdministrationViewModel listAdministrationViewModel = new ListAdministrationViewModel();
            try
            {
                listAdministrationViewModel.Administrations = _unitOfWork.AdministrationRepository.GetAll().ToList();

                return listAdministrationViewModel;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
