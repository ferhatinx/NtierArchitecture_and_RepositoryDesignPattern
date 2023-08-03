

using Microsoft.EntityFrameworkCore;
using NtierDataAccess.Context;
using NtierDataAccess.Interfaces;
using NtierEntities.Domains;
using System.Linq.Expressions;

namespace NtierDataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly TodoContext _context;
    private readonly DbSet<T> Table;

    public Repository(TodoContext context)
    {
        _context = context;
        Table = _context.Set<T>();

    }
    public async Task CreateAsync(T entity)
    {
       await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T t)
    {
        Table.Remove(t);
    }

    public async Task<List<T>> GetAllAsync()
    => await _context.Set<T>().AsNoTracking().ToListAsync();
    

    public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
    {
        return asNoTracking ?
            await Table.SingleOrDefaultAsync(filter) :
            await Table.AsNoTracking().SingleOrDefaultAsync(filter);
            
    }

    public async Task<T> GetByIdAsync(object id)
    =>  await Table.AsNoTracking().SingleOrDefaultAsync(x=>x.Id == (int)id);
    

    public IQueryable GetQueryAsync()
    {
        return Table.AsQueryable();
    }

    public async Task Update(T entity, T unchanged)
    {
      
       _context.Entry(unchanged).CurrentValues.SetValues(entity);
        Table.Update(entity);
    }
}
