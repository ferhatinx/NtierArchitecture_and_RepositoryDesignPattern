using Udemy.RepositoryDesignPattern.Data.Context;
using Udemy.RepositoryDesignPattern.Data.Entities;
using Udemy.RepositoryDesignPattern.Data.Interfaces;

namespace Udemy.RepositoryDesignPattern.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly BankContext _bankContext;

    public AccountRepository(BankContext bankContext)
    {
        _bankContext = bankContext;
    }
    public void Create(Account account)
    {
        _bankContext.Accounts.Add(account);
        _bankContext.SaveChanges();
    }
}
