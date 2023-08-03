

using NtierDataAccess.Interfaces;
using NtierEntities.Domains;

namespace NtierDataAccess.Uow
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        Task SaveChangesAsync();
    }
}
