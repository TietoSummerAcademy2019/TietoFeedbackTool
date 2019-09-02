using System.Collections.Generic;
using System.Linq;
using TietoJar.Application.Interfaces;
using TietoJar.Persistence;
using TietoJar.Domain;
using System;

namespace TietoJar.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        public readonly ITietoJarContext _context;

        public AccountService(ITietoJarContext context)
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

        public Account UpdateAccount(string login, Account account)
        {
			var _account = _context.Accounts.SingleOrDefault(x => x.Login == login);
			_account.Name = account.Name;
			_account.Password = account.Password;
			_context.SaveChanges();
			return account;
		}

        public void DeleteAccount(string login)
        {
            var account = _context.Accounts.Where(x => x.Login == login).FirstOrDefault();
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }
    }
}
