using Udemy.RepositoryDesignPattern.Data.Entities;
using Udemy.RepositoryDesignPattern.Models;

namespace Udemy.RepositoryDesignPattern.Mappings
{
    public class AccountMapper : IAccountMapper
    {
        public Account Map(AccountCreateModel accountCreateModel)
        {
            return new Account()
            {
                AccountNumber = accountCreateModel.AccountNumber,
                AppUserId = accountCreateModel.AppUserId,
                Balance = accountCreateModel.Balance,

            };
        }
    }
}
