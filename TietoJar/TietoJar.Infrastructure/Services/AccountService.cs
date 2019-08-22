using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TietoJar.Application;
using TietoJar.Application.Interfaces;
using TietoJar.Domain;
using TietoJar.Persistence;

namespace TietoJar.Infrastructure.Services
{

	public class AccountService : IAccountService
	{
		public readonly TietoJarContext _context;
		public AccountService(TietoJarContext context)
		{
			_context = context;
		}
		public List<Account> GetAccounts()
		{
			var accounts = _context.Accounts.ToList();
			return accounts;
		}
		public Account AddAccount(Account account)
		{
			_context.Accounts.Add(account);
			_context.SaveChanges();
			return account;
		}
		public Account GetAccount(string login)
		{
			return _context.Accounts.SingleOrDefault(x => x.Login == login);
		}
		public Account UpdateAccount(Account account)
		{
			_context.Accounts.Update(account);
			_context.SaveChanges();
			return account;
		}
		public Account DeleteAccount(string login)
		{
			Account account = _context.Accounts.Where(x => x.Login == login).FirstOrDefault();
			_context.Accounts.Remove(account);
			_context.SaveChanges();
			return account;
		}
	}
}
