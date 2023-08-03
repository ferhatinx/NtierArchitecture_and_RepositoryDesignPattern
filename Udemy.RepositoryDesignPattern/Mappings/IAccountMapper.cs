using Udemy.RepositoryDesignPattern.Data.Entities;
using Udemy.RepositoryDesignPattern.Models;

namespace Udemy.RepositoryDesignPattern.Mappings
{
    public interface IAccountMapper
    {
        Account Map(AccountCreateModel accountCreateModel);
    }
}
