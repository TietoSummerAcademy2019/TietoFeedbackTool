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
        public List<Account> GetAccounts()
        {
            return _accountService.GetAccounts();
        }

        [HttpGet("{login}")]
        public Account GetAccount(string login)
        {
            return _accountService.GetAccount(login);
        }

        [HttpPut("{Id}")]
        public Account UpdateAccountById(int id, [FromBody]Account account)
        {
            return _accountService.UpdateAccountById(id, account);
        }

        [HttpDelete("{login}")]
        public NoContentResult DeleteAccount(string login)
        {
            _accountService.DeleteAccount(login);
			return NoContent();
        }
    }
}