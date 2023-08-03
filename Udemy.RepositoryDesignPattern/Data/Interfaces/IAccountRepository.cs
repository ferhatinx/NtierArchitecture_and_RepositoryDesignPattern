using Udemy.RepositoryDesignPattern.Data.Entities;

namespace Udemy.RepositoryDesignPattern.Data.Interfaces;

public interface IAccountRepository
{

    void Create(Account account);
}
