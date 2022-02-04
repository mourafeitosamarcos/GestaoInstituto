using GestaoInstituto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInstituto.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
        bool IsExist(string email);
        User IsAuthenticate(string email, string senha);
    }
}
