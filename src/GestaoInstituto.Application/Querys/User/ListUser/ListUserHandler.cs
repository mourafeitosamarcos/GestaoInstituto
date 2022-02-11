using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Querys.User.ListUser
{
    public class ListUserHandler : IRequestHandler<ListUserQuery, OneOf<ListUserViewModel, string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<ListUserViewModel, string>> Handle(ListUserQuery request, CancellationToken cancellationToken)
        {
            ListUserViewModel listUserViewModel = new ListUserViewModel();
            try
            {
                listUserViewModel.Users = _unitOfWork.UserRepository.GetAll().ToList();

                return listUserViewModel;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
