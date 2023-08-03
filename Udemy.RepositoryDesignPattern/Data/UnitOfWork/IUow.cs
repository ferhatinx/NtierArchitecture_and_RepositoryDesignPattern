using Udemy.RepositoryDesignPattern.Data.Interfaces;

namespace Udemy.RepositoryDesignPattern.Data.UnitOfWork;

public interface IUow
{
    IRepository<T> GetRepository<T>() where T : class,new();
    void SaveChanges();

}