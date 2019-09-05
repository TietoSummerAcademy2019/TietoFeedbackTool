using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Domain;

namespace TietoFeedbackTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
		public readonly IAccountRepository _accountRepository;
		public readonly IUnitOfWork _unitOfWork;
		public AccountController(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
			_accountRepository = accountRepository;
			_unitOfWork = unitOfWork;

		}

        //ACOUNTS CRUD
        [HttpPost]
        public void Add([FromBody]Account account)
        {
			var _account = _unitOfWork.Account.GetAccount(account.Login);
			
			if (_account == null)
			{
				_unitOfWork.Account.Add(account);
				_unitOfWork.Complete();
			}
			else
			{
				 Conflict("Account already exist");
			}
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {
			var account = _accountRepository.GetAll();
			if (account.Equals(0))
			{
				return NotFound("No Accounts Found, try adding Account");
			}
			else
			{
				return _unitOfWork.Account.GetAll().ToList();
			}
        }

        [HttpGet("{login}")]
        public ActionResult<Account> GetAccount(string login)
        {
			var account = _accountRepository.GetAccount(login);
			if (account == null)
			{
				return NotFound("Cant find Account with this login");
			}
			else
			{
				return account;
			}
        }

   //     [HttpPut("{login}")]
   //     public ActionResult<Account> UpdateAccount(string login, [FromBody]Account account)
   //     {
			//var _account = _unitOfWork.Account.GetAccount(login);
			//if (_account == null)
			//{
			//	return NotFound("Cant find Account with this login");
			//}
			//else
			//{
			//	//return 1;
			//}
   //     }

        [HttpDelete("{login}")]
        public ActionResult DeleteAccount(string login)
        {
			var _account = _unitOfWork.Account.GetAccount(login);
			if (_account == null)
			{
				return NotFound("Cant find Account with this login");
			}
			else
			{
				_unitOfWork.Account.Remove(_account);
				_unitOfWork.Complete();
				return NoContent();
			}
        }
    }
}
