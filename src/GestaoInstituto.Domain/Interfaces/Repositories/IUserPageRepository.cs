using GestaoInstituto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoInstituto.Domain.Interfaces.Repositories
{
    public interface IUserPageRepository : IBaseRepository<UserPage, int>
    {
        List<UserPage> GetByUserId(int userId);
    }
}
