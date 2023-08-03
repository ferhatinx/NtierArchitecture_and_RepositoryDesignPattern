using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Udemy.RepositoryDesignPattern.Data.Context;
using Udemy.RepositoryDesignPattern.Data.Entities;
using Udemy.RepositoryDesignPattern.Data.Interfaces;
using Udemy.RepositoryDesignPattern.Data.UnitOfWork;
using Udemy.RepositoryDesignPattern.Mappings;
using Udemy.RepositoryDesignPattern.Models;
using Udemy.RepositoryDesignPattern.Repositories;

namespace Udemy.RepositoryDesignPattern.Controllers
{
    public class AccountController : Controller
    {
        #region Ctor-1
        //private readonly BankContext _context;
        //private readonly IAppUserRepository _appUserRepository;
        //private readonly IUserMapper _userMapper;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IAccountMapper _accountMapper;
        //public AccountController(BankContext context, IAppUserRepository appUserRepository, IUserMapper userMapper, IAccountRepository accountRepository, IAccountMapper accountMapper)
        //{
        //    _context = context;
        //    _appUserRepository = appUserRepository;
        //    _userMapper = userMapper;
        //    _accountRepository = accountRepository;
        //    _accountMapper = accountMapper;
        //}
        #endregion
        #region Ctor-2
        //private readonly IRepository<Account> _accountRepository;
        //private readonly IRepository<AppUser> _userRepository;
        //public AccountController(IRepository<Account> accountRepository, IRepository<AppUser> userRepository)
        //{
        //    _accountRepository = accountRepository;
        //    _userRepository = userRepository;
        //}
        #endregion

        private readonly IUow _uow;

        public AccountController(IUow uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(int id)
        {

            var userInfo = _uow.GetRepository<AppUser>().GetById(id);
            var userModel = new UserListModel()
            {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            };
            //var userInfo = _userMapper.MapToUser(_appUserRepository.GetById(id));
            return View(userModel);
        }
        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _uow.GetRepository<Account>().Create(new()
            {
                AccountNumber = accountCreateModel.AccountNumber,
                Balance = accountCreateModel.Balance,
                AppUserId = accountCreateModel.AppUserId

            });
            //_accountRepository.Create(_accountMapper.Map(accountCreateModel));
            return RedirectToAction("Index","Home");
        }
        public IActionResult GetByUserId(int userId) 
        {
            var user = _uow.GetRepository<AppUser>().GetById(userId);
            ViewBag.fullname = user.Name + " " + user.Surname;
            var query = _uow.GetRepository<Account>().GetQueryable();
            var accountList = query.Where(x=>x.AppUserId == userId).Select(x=> new AccountListModel
            {
                Id=x.Id,
                AccountNumber= x.AccountNumber,
                Balance = x.Balance,
                AppUserId = x.AppUserId,
               
            }).ToList();
           
             return View(accountList);
        }
        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();
            var accounts = query.Where(x => x.Id != accountId).ToList();
            


            var list = new List<AccountListModel>();

            ViewBag.senderaccountid = accountId;
            foreach (var account in accounts)
            {
                list.Add(new AccountListModel
                {
                    Id = account.Id,
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    AppUserId = account.AppUserId,
                });
            }
            

            return View(new SelectList(list,"Id","AccountNumber"));
        }
        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel sendMoneyModel)
        {
            var senderAccount = _uow.GetRepository<Account>().GetById(sendMoneyModel.SenderId);
            senderAccount.Balance -= sendMoneyModel.Amount;
            _uow.GetRepository<Account>().Update(senderAccount);

            var account = _uow.GetRepository<Account>().GetById(sendMoneyModel.AccountId);
            account.Balance+= sendMoneyModel.Amount;
            _uow.GetRepository<Account>().Update(account);


            
            return RedirectToAction("Index","Home");
        }
    }
}
