using Udemy.RepositoryDesignPattern.Data.Context;
using Udemy.RepositoryDesignPattern.Data.Entities;
using Udemy.RepositoryDesignPattern.Data.Interfaces;

namespace Udemy.RepositoryDesignPattern.Repositories;
public class AppUserRepository  : IAppUserRepository
{
    private readonly BankContext _bankContext;

    public AppUserRepository(BankContext bankContext)
    {
        _bankContext = bankContext;
    }

    public List<AppUser> GetAll()
    {
        return _bankContext.AppUsers.ToList();
    }
    public AppUser GetById(int id)
    {
        return _bankContext.AppUsers.SingleOrDefault(x=>x.Id == id);
    }
    public void Create(AppUser user) 
    {
        
        _bankContext.AppUsers.Add(user);
        _bankContext.SaveChanges();
    }
}
