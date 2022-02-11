using GestaoInstituto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Domain.Interfaces.Repositories
{
    public interface IUserAdministrationRepository : IBaseRepository<UserAdministration, int>
    {
        List<UserAdministration> GetByUserId(int userId);
    }
}
