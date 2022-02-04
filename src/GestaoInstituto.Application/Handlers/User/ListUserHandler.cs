using GestaoInstituto.Application.Model;
using GestaoInstituto.Application.Querys.User;
using GestaoInstituto.Domain.Entities;
using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Handlers.User
{
    public class ListUserHandler : IRequestHandler<ListUserQuery, OneOf<List<Domain.Entities.User>, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<List<Domain.Entities.User>, CustomErrors>> Handle(ListUserQuery request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            try
            {
                List<Domain.Entities.User> usuarios = _unitOfWork.UserRepository.GetAll().ToList();
                return usuarios;
            }
            catch (Exception ex)
            {
                customErrors.MessageError = ex.Message;
                return customErrors;
            }
            
        }
    }
}
