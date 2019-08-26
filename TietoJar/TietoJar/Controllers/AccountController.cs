using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TietoJar.Application.Interfaces;
using TietoJar.Domain;

namespace TietoJar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        public readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //ACOUNTS CRUD
        [HttpPost]
        public Account AddAccount([FromBody]Account account)
        {
            return _accountService.AddAccount(account);
        }

        [HttpGet]
        public ActionResult<List<Account>> GetAccounts()
        {
			var account = _accountService.GetAccounts();

			if (account.Count == 0)
			{
				return NotFound();
			}
			else
			{
				return _accountService.GetAccounts();
			}
        }

        [HttpGet("{login}")]
        public ActionResult<Account> GetAccount(string login)
        {
			var account = _accountService.GetAccount(login);

			if (account == null)
			{
				return NotFound();
			}
			else
			{
				return account;
			}
        }

        [HttpPut("{login}")]
        public ActionResult<Account> UpdateAccount(string login, [FromBody]Account account)
        {
			var _account = _accountService.GetAccount(login);

			if (_account == null)
			{
				return NotFound();
			}
			else
			{
				return _accountService.UpdateAccount(login, account);
			}
        }

        [HttpDelete("{login}")]
        public NoContentResult DeleteAccount(string login)
        {
            _accountService.DeleteAccount(login);
			return NoContent();
        }
    }
}