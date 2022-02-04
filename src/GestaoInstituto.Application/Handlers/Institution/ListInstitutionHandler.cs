using GestaoInstituto.Application.Model;
using GestaoInstituto.Application.Querys.Institution;
using GestaoInstituto.Domain.UoW;
using MediatR;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoInstituto.Application.Handlers.Institution
{
    public class ListInstitutionHandler : IRequestHandler<ListInstitutionQuery, OneOf<List<Domain.Entities.Institution>, CustomErrors>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListInstitutionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OneOf<List<Domain.Entities.Institution>, CustomErrors>> Handle(ListInstitutionQuery request, CancellationToken cancellationToken)
        {
            CustomErrors customErrors = new CustomErrors();
            try
            {
                List<Domain.Entities.Institution> institutions = _unitOfWork.InstitutionRepository.GetAll().ToList();

                return institutions;
            }
            catch (Exception ex)
            {
                customErrors.MessageError = ex.Message;
                return customErrors;
            }
        }
    }
}
