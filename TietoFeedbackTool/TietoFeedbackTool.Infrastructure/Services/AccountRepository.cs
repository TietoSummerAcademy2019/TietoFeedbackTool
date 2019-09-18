using System.Collections.Generic;
using System.Linq;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Persistence;
using TietoFeedbackTool.Domain;
using System;
using Microsoft.EntityFrameworkCore;

namespace TietoFeedbackTool.Infrastructure.Services
{
	public class AccountRepository : Repository<Account>, IAccountRepository
	{
		public AccountRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}

		public new Account Add(Account account)
		{
			account.QuestionsKey = GetNewKey();
			_context.Accounts.Add(account);
			return account;
		}

		public new Account AddRange(IEnumerable<Account> accounts)
		{
			accounts.ToList().ForEach(x => x.QuestionsKey = GetNewKey());
			_context.Accounts.AddRange(accounts);
			return accounts.First();
		}

		public new Account GetByString(string login)
		{
			return _context.Accounts.Include(x => x.Questions).ThenInclude(questions => questions.PuzzleAnswers).Where(x => x.Login == login).SingleOrDefault();
		}

		public void UpdateAccount(Account account, string login)
		{
			var _account = _context.Accounts.SingleOrDefault(x => x.Login == login);
			_account.Name = account.Name;
		}

		public TietoFeedbackToolContext TietoFeedbackToolContext
		{
			get { return _context as TietoFeedbackToolContext; }
		}

		public string GetNewKey()
		{
			bool isInDB = true;
			string key = null;

			while (isInDB == true)
			{
				int size = 32;
				Random rand = new Random((int)DateTime.Now.Ticks);
				string input = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
				key = new string(Enumerable.Range(0, size).Select(x => input[rand.Next(0, input.Length)]).ToArray());

				if (_context.Accounts.Where(x => x.QuestionsKey == key).ToList().Count == 0)
				{
					isInDB = false;
				}
			}
			return key;
		}
	}
}
