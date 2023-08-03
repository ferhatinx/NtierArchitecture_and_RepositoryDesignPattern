using Udemy.RepositoryDesignPattern.Data.Context;
using Udemy.RepositoryDesignPattern.Data.Interfaces;
using Udemy.RepositoryDesignPattern.Repositories;

namespace Udemy.RepositoryDesignPattern.Data.UnitOfWork;
public class Uow : IUow 
{
    private readonly BankContext _context;

    public Uow(BankContext context)
    {
        _context = context;
    }

    public IRepository<T> GetRepository<T>() where T : class,new()
    {
        return new Repository<T>(_context);
    }
    public void SaveChanges()
    {
        _context.SaveChanges();
    }


}
