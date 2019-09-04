using System.Collections.Generic;
using System.Linq;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Persistence;
using TietoFeedbackTool.Domain;
using System;

namespace TietoFeedbackTool.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        public readonly ITietoFeedbackToolContext _context;

        public AccountService(ITietoFeedbackToolContext context)
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
