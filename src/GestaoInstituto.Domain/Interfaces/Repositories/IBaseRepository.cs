using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoInstituto.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T, TId> where T : class
    {
        T GetById(TId id);
        IList<T> GetAll();
        T Salvar(T t);
        T Atualizar(T t);
        T Deletar(TId id);
    }
}
