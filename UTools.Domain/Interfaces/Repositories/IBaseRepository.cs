using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UTools.Domain.Entities;

namespace UTools.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T current, T obj);
        Task<bool> DeleteAsync(T obj);
        Task<bool> DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);

    }
}
