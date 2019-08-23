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
            var account = _context.Accounts.SingleOrDefault(x => x.Login == login);
            if (account != null)
            {
                return _context.Accounts.SingleOrDefault(x => x.Login == login);
            }
            else
            {
                throw new Exception("Not found");
            }
        }

        public Account UpdateAccountById(int id, Account account)
        {
			var _account = _context.Accounts.SingleOrDefault(x => x.Id == id);
			if (_account == null)
			{
				throw new Exception("Not found");
			}
			else
			{
				_account.Login = account.Login;
				_account.Password = account.Password;
				_context.SaveChanges();
				return account;
			}
		}

        public void DeleteAccount(string login)
        {
            var account = _context.Accounts.Where(x => x.Login == login).FirstOrDefault();
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }
    }
}