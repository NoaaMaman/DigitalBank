using Microsoft.EntityFrameworkCore.Update.Internal;
using OriginalBankAPI.Models;
using System.Linq.Expressions;

namespace OriginalBankAPI.Services
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> filters,
                                            int? skip = null,
                                            int? take = null,
                                            params Expression<Func<T, object>>[] includes);

        public Task<List<T>> GetAsync(int? skip = null, int? take = null, params Expression<Func<T, object>>[] includes);


        public Task<T?> GetByIdAsync(int id ,params Expression<Func<T, object>>[] includes);

        public Task<int> InsertAsync(T entity);

        public void Update(T entity);

        public void Delete(T entity);

        Task SaveChangesAsync();
    }
}
