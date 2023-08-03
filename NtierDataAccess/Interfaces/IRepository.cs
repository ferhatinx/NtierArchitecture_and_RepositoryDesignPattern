

using Microsoft.EntityFrameworkCore;
using NtierEntities.Domains;
using System.Linq.Expressions;

namespace NtierDataAccess.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(object id);

    Task<T> GetByFilterAsync(Expression<Func<T,bool>> filter, bool asNoTracking = false);

    Task CreateAsync(T entity);
    Task Update(T entity, T unchanged);
    void Delete(T t);
   IQueryable GetQueryAsync();
 



}
