using Udemy.RepositoryDesignPattern.Data.Entities;

namespace Udemy.RepositoryDesignPattern.Data.Interfaces;

public interface IAppUserRepository
{
    List<AppUser> GetAll();
    AppUser GetById(int id);
    void Create(AppUser user);
}
