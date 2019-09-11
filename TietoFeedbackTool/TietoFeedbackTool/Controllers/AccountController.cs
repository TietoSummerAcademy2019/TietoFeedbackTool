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
		/// <summary>
		/// Add specyfic account
		/// </summary>
		/// <param name="account"></param>
		/// <returns>A newly created account</returns>
		/// <response code="200">Returns the newly created account</response>
		[HttpPost]
        public ActionResult<Account> Add([FromBody]Account account)
        {
			var _account = _unitOfWork.Account.GetByString(account.Login);
			if (_account == null)
			{
				_unitOfWork.Account.Add(account);
				_unitOfWork.Complete();
				return Ok(account);
			}
			else
			{
				return Conflict("Account already exist");
			}
        }

		/// <summary>
		/// Get list of all accounts
		/// </summary>
		/// <returns>List of all accounts</returns>
		/// <response code="200">Returns the list of account</response>
		[HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {
			var account = _unitOfWork.Account.GetAll();
			if (account == null)
			{
				return NotFound("No Accounts Found, try adding Account");
			}
			else
			{
				return Ok(_unitOfWork.Account.GetAll().ToList());
			}
        }

		/// <summary>
		/// Get specyfic account with all related qustions and answers
		/// </summary>
		/// <param name="login"></param>
		/// <returns>Account with all related items</returns>
		/// <response code="200">Returns account with all related items</response>
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
				return Ok(account);
			}
        }

		/// <summary>
		/// Edit specyfic account
		/// </summary>
		/// <param name="login"></param>
		/// <param name="account"></param>
		/// <returns>Updated account</returns>
		/// <response code="200">Returns updated account</response>
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
				_unitOfWork.Account.UpdateAccount(account, login);
				_unitOfWork.Complete();
				return Ok(account);
			}
		}

		/// <summary>
		/// Delete specyfic account
		/// </summary>
		/// <param name="login"></param>
		/// <returns>No content</returns>
		/// <response code="200">No content</response>
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
