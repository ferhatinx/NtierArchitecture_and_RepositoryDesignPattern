using Microsoft.AspNetCore.Mvc;
using Udemy.RepositoryDesignPattern.Data.Context;
using Udemy.RepositoryDesignPattern.Data.Entities;
using Udemy.RepositoryDesignPattern.Data.Interfaces;
using Udemy.RepositoryDesignPattern.Data.UnitOfWork;
using Udemy.RepositoryDesignPattern.Mappings;
using Udemy.RepositoryDesignPattern.Models;
using Udemy.RepositoryDesignPattern.Repositories;

namespace Udemy.RepositoryDesignPattern.Controllers;

public class HomeController : Controller
{
    #region Ctor-1
    //private readonly BankContext _bankContext;
    //private readonly IAppUserRepository _appUserRepository;
    //private readonly IUserMapper _userMapper;

    //public HomeController(BankContext bankContext, IAppUserRepository appUserRepository, IUserMapper userMapper)
    //{
    //    _bankContext = bankContext;
    //    _appUserRepository = appUserRepository;
    //    _userMapper = userMapper;
    //}

    #endregion
    private readonly IUow _uow;
    private readonly IUserMapper _userMapper;
    public HomeController(IUow uow, IUserMapper userMapper)
    {
        _uow = uow;
        _userMapper = userMapper;
    }

    public IActionResult Index()
    {
        return View(_userMapper.MapToUserList(_uow.GetRepository<AppUser>().GetAll()));
    }
}
