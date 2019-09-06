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
		public readonly IUnitOfWork _unitOfWork;
		public AccountController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;

		}

        //ACOUNTS CRUD
        [HttpPost]
        public ActionResult<Account> Add([FromBody]Account account)
        {
			var _account = _unitOfWork.Account.GetAccount(account.Login);
			
			if (_account == null)
			{
				_unitOfWork.Account.Add(account);
				_unitOfWork.Complete();
				return account;
			}
			else
			{
				return Conflict("Account already exist");
			}
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {
			var account = _unitOfWork.Account.GetAll();
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
			var account = _unitOfWork.Account.GetAccount(login);
			if (account == null)
			{
				return NotFound("Cant find Account with this login");
			}
			else
			{
				return account;
			}
        }

		[HttpPut("{login}")]
		public ActionResult<Account> UpdateAccount(string login, [FromBody]Account account)
		{
			var _account = _unitOfWork.Account.GetAccount(login);
			if (_account == null)
			{
				return NotFound("cant find account with this login");
			}
			else
			{
				//return 1;
				//_unitOfWork.Account.Add(_account);
				//_unitOfWork.Complete();
				_account.Name = account.Name;
				_account.Password = account.Password;
				_unitOfWork.Complete();
				return _account;
			}
		}

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
