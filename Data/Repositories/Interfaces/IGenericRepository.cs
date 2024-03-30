using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAll(); 
        Task<T?> GetById(Guid guid);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);


    }
}
