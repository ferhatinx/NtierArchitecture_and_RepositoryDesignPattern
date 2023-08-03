using Udemy.RepositoryDesignPattern.Data.Entities;
using Udemy.RepositoryDesignPattern.Models;

namespace Udemy.RepositoryDesignPattern.Mappings;
public class UserMapper : IUserMapper
{
    public List<UserListModel> MapToUserList(List<AppUser> appUsers)
    {
        return appUsers.Select(x => new UserListModel
        {
            Id = x.Id,
            Surname = x.Surname,
            Name = x.Name
        }).ToList();
    }
    public UserListModel MapToUser(AppUser appUser)
    {
        return new UserListModel
        {
            Id = appUser.Id,
            Surname = appUser.Surname,
            Name = appUser.Name
        };
    }
}
