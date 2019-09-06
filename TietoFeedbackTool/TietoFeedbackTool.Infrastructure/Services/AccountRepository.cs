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

		public Account GetAccount(string login)
		{
			return _context.Accounts.Where(x => x.Login == login).Include("Surveys.SurveyPuzzles.OpenPuzzleAnswers").SingleOrDefault();
		}

		public void UpdateAccount(Account account, string login)
		{
			var _account = _context.Accounts.SingleOrDefault(x => x.Login == login);
			_account.Name = account.Name;
			_account.Password = account.Password;
		}

		public TietoFeedbackToolContext TietoFeedbackToolContext
		{
			get { return _context as TietoFeedbackToolContext; }
		}
	}
}
