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
		/// Add specific account
		/// </summary>
		/// <param name="account">Account object</param>
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
		/// Get specific domains by user login
		/// </summary>
		/// <param name="login">Account.Login</param>
		/// <returns>List of domains</returns>
		/// <response code="200">Returns list with all domains from user</response>
		[HttpGet("userdomains/{login}")]
		public ActionResult<List<string>> GetUserDomains(string login)
		{
			var account = _unitOfWork.Account.GetByString(login);
			if (account == null)
			{
				return NotFound("There is no account with that login");
			}
			else
			{
				var domains = _unitOfWork.Account.GetUserDomains(login);
				return Ok(domains);
			}
		}

		/// <summary>
		/// Get specific account with all related qustions and answers
		/// </summary>
		/// <param name="login">Account.Login</param>
		/// <returns>Account with all related items</returns>
		/// <response code="200">Returns account with all related items</response>
		[HttpGet("{login}")]
		public ActionResult<Account> GetAccount(string login)
		{
			var account = _unitOfWork.Account.GetByString(login);
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
		/// Edit specific account
		/// </summary>
		/// <param name="login">Account.Login</param>
		/// <param name="account">Account object</param>
		/// <returns>Updated account</returns>
		/// <response code="200">Returns updated account</response>
		[HttpPut("{login}")]
		public ActionResult<Account> UpdateAccount(string login, [FromBody]Account account)
		{
			var _account = _unitOfWork.Account.GetByString(login);
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
		/// Delete specific account
		/// </summary>
		/// <param name="login">Account.Login</param>
		/// <returns>No content</returns>
		/// <response code="200">No content</response>
		[HttpDelete("{login}")]
		public ActionResult DeleteAccount(string login)
		{
			var _account = _unitOfWork.Account.GetByString(login);
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
