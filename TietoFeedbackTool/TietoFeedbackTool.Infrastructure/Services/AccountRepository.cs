using System.Collections.Generic;
using System.Linq;
using TietoFeedbackTool.Application.Interfaces;
using TietoFeedbackTool.Persistence;
using TietoFeedbackTool.Domain;
using System;
using Microsoft.EntityFrameworkCore;

namespace TietoFeedbackTool.Infrastructure.Services
{
	/// <summary>
	/// Repository contains handlig method of Account model.
	/// </summary>
	public class AccountRepository : Repository<Account>, IAccountRepository
	{
		public AccountRepository(ITietoFeedbackToolContext context) : base(context)
		{
		}

		/// <summary>
		/// Modified method from basic repository, to add new account with newly generated question key
		/// </summary>
		/// <param name="account"></param>
		/// <returns>Account with newly generated question key</returns>
		public new Account Add(Account account)
		{
			account.QuestionsKey = GetNewKey();
			_context.Accounts.Add(account);
			return account;
		}

		/// <summary>
		/// Modified method from basic repository, to add new list of account with newly generated question key
		/// </summary>
		/// <param name="accounts"></param>
		/// <returns>List of account w newly generated question key</returns>
		public new Account AddRange(IEnumerable<Account> accounts)
		{
			accounts.ToList().ForEach(x => x.QuestionsKey = GetNewKey());
			_context.Accounts.AddRange(accounts);
			return accounts.First();
		}

		/// <summary>
		/// Modified method from basic repository. 
		/// Get account and all related Question and PuzzleAnswers to it by account login
		/// </summary>
		/// <param name="login">Account login</param>
		/// <returns>Searched acccount</returns>
		public new Account GetByString(string login)
		{
			return _context.Accounts.Include(x => x.Questions).ThenInclude(questions => questions.PuzzleAnswers).Where(x => x.Login == login).SingleOrDefault();
		}

		/// <summary>
		/// Update name of specific account
		/// </summary>
		/// <param name="account">Account obj, Account name</param>
		/// <param name="login">Account login</param>
		public void UpdateAccount(Account account, string login)
		{
			var _account = _context.Accounts.SingleOrDefault(x => x.Login == login);
			_account.Name = account.Name;
		}

		public TietoFeedbackToolContext TietoFeedbackToolContext
		{
			get { return _context as TietoFeedbackToolContext; }
		}

		/// <summary>
		/// Get list of domains related to specific account
		/// </summary>
		/// <param name="login">Account login</param>
		/// <returns>List of domains related to specific account</returns>
		public List<string> GetUserDomains(string login)
		{
			Account account = _context.Accounts.Include(x => x.Questions).Where(x => x.Login == login).SingleOrDefault();
			List<string> domains = account.Questions.Select(x => x.Domain).Distinct().ToList();
			return domains;
		}

		/// <summary>
		/// Generate new question key
		/// </summary>
		/// <returns>New key</returns>
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
