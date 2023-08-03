

using NtierDataAccess.Context;
using NtierDataAccess.Interfaces;
using NtierDataAccess.Repositories;
using NtierEntities.Domains;

namespace NtierDataAccess.Uow
{
    public class Uow : IUow
    {
        private readonly TodoContext _context;

        public Uow(TodoContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
