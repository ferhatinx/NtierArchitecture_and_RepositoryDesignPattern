using Udemy.RepositoryDesignPattern.Data.Entities;
using Udemy.RepositoryDesignPattern.Models;

namespace Udemy.RepositoryDesignPattern.Mappings
{
    public interface IUserMapper
    {
        List<UserListModel> MapToUserList(List<AppUser> appUsers);
        UserListModel MapToUser(AppUser appUser);
    }
}
