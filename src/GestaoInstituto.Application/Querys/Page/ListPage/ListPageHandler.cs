using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Querys.Page.ListPage
{
    public class ListPageHandler : IRequestHandler<ListPageQuery, OneOf<ListPageViewModel, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListPageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<ListPageViewModel, string>> Handle(ListPageQuery request, CancellationToken cancellationToken)
        {
            ListPageViewModel listPageViewModel = new ListPageViewModel();
            try
            {
                listPageViewModel.Pages = _unitOfWork.PageRepository.GetAll().ToList();

                return listPageViewModel;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
