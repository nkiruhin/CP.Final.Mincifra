using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP.Final.Mincifra.SharedKernel.Interfaces
{
    public interface IRepository
    {
        IQueryable<T> GetQuery<T>() where T : BaseEntity;
        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity;
        Task<List<T>> ListAsync<T>() where T : BaseEntity;
        Task<List<T>> ListWithIncludeAsync<T>(string path) where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        Task UpdateAsync<T>(T entity) where T : BaseEntity;
        Task DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}