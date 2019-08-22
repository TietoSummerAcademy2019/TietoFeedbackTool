using System;
using System.Collections.Generic;
using System.Text;
using TietoJar.Domain;


namespace TietoJar.Application.Interfaces
{

	public interface IAccountService
	{
		List<Account> GetAccounts();
		Account AddAccount(Account account);
		Account GetAccount(string login);
		Account UpdateAccount(Account account);
		Account DeleteAccount(string login);
	}
}
