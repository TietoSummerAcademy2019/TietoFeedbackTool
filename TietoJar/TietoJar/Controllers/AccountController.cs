using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TietoJar.Persistence;
using TietoJar.Application;
using TietoJar.Domain;
using TietoJar.Application.Interfaces;

namespace TietoJar.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController: Controller
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
		public List<Account> GetAccounts()
		{
			return _accountService.GetAccounts();
		}
		[HttpGet("{login}")]
		public Account GetAccount(string login)
		{
			return _accountService.GetAccount(login);
		}
		[HttpPut]
		public Account UpdateAccount([FromBody]Account account)
		{
			return _accountService.UpdateAccount(account);
		}
		[HttpDelete("{login}")]
		public Account DeleteAccount(string login)
		{
			return _accountService.DeleteAccount(login);
		}
	}
}
